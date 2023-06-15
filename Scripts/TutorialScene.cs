using Godot;
using System;

public partial class TutorialScene : Control
{
	Control dialog, options, paramater;
	Button button;
	RichTextLabel richTextLabel;
	AnimationPlayer animationPlayer;

	int count = 0;

	public override void _Ready()
	{
		dialog = GetNode<Control>("Dialog");
		options = GetNode<Control>("Options");
		paramater = GetNode<Control>("Paramater");
		button = GetNode<Button>("Panel/Button");
		richTextLabel = GetNode<RichTextLabel>("Panel/RichTextLabel");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

		richTextLabel.Text = "Parameter dari kiri ke kanan ada Akademis, Sosial, Keuangan, dan Cinta. Jika salah satu telah menyentuh angka 0 atau 100. Maka game akan berakhir. Setiap parameter akan memberikan ending yang berbeda.";

		dialog.Modulate = new Color(0.4f, 0.4f, 0.4f);
		options.Modulate = new Color(0.4f, 0.4f, 0.4f);
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			paramater.Modulate  = new Color(0.4f, 0.4f, 0.4f);
			dialog.Modulate = new Color(1f, 1f, 1f);
			options.Modulate = new Color(0.4f, 0.4f, 0.4f);

			richTextLabel.Text = "Pertanyaan akan disampaikan oleh setiap karakter. Pertanyaan dari karakter dapat berbentuk bahasa formal ataupun informal. Pertanyaan dapat memiliki makna ganda ataupun berkelanjutan, anda harus memperhatikan itu dengan baik.";
			animationPlayer.Play("TextAnim");
		}
		if (count == 2)
		{
			paramater.Modulate  = new Color(0.4f, 0.4f, 0.4f);
			dialog.Modulate = new Color(0.4f, 0.4f, 0.4f);
			options.Modulate = new Color(1f, 1f, 1f);

			richTextLabel.Text = "Berdasarkan pertanyaan disampaikan, nantinya anda akan dihadapkan oleh beberapa jawaban. Setiap jawaban akan memberikan efek yang berbeda kepada nilai parameter.";
			animationPlayer.Play("TextAnim");
		}
		if (count == 3)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/name_select.tscn");
		}
	}

	void OnAnimationFinished(StringName animName)
	{
		if (count == 2)
		{
			if (animName == "TextAnim") button.Text = "Mulai Bermain!";
		}
	}
}
