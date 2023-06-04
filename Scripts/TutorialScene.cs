using Godot;
using System;

public partial class TutorialScene : Control
{
	int count = 0;

	Control cw;
	AnimationPlayer cwanim;
	Label tutorialBoxLabel;
	Button skipBtn, nextBtn;

	public override void _Ready()
	{
		skipBtn = GetNode<Button>("TutorialBox/SkipButton");
		nextBtn = GetNode<Button>("TutorialBox/NextButton");
		tutorialBoxLabel = GetNode<Label>("TutorialBox/Label");

		tutorialBoxLabel.Text = "Parameter dari kiri ke kanan ada Akademis, Sosial, Keuangan, dan Cinta. Jika salah satu telah menyentuh angka 0 atau 100. Maka game akan berakhir. Setiap parameter akan memberikan ending yang berbeda.";

		cw = GetNode<Control>("ConfirmationWindow");
		cwanim = GetNode<AnimationPlayer>("ConfirmationWindow/CWAnimation");
		cw.Visible = false;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
		{
			cwanim.Play("CW Close");
		}
	}

	void OnSkipButtonPressed()
	{
		GetTree().ChangeSceneToFile("Scenes/name_select.tscn");
	}

	void OnNextButtonPressed()
	{
		var parameter = GetNode<Control>("Paramater");
		var dialog = GetNode<Control>("Dialog");
		var options = GetNode<Control>("Options");

		count++;

		if (count == 1)
		{
			tutorialBoxLabel.Text = "Pertanyaan akan disampaikan oleh setiap karakter. Pertanyaan dari karakter dapat berbentuk bahasa formal ataupun informal. Pertanyaan dapat memiliki makna ganda ataupun berkelanjutan, anda harus memperhatikan itu dengan baik.";
			parameter.Modulate = new Color(0.5f, 0.5f, 0.5f);
			dialog.Modulate = new Color(1, 1, 1);
		}
		else if (count == 2)
		{
			tutorialBoxLabel.Text = "Berdasarkan pertanyaan disampaikan, nantinya anda akan dihadapkan oleh beberapa jawaban. Setiapjawaban akan memberikan efek yang berbeda kepada nilai parameter.";
			parameter.Modulate = new Color(0.5f, 0.5f, 0.5f);
			dialog.Modulate = new Color(0.5f, 0.5f, 0.5f);
			options.Modulate = new Color(1, 1, 1);
			skipBtn.Visible = false;
			nextBtn.Position = new Vector2(64, 192);
			nextBtn.Size = new Vector2(384, 40);
			nextBtn.Text = "Mulai Bermain!";
		}
		else if (count == 3)
		{
			GetTree().ChangeSceneToFile("Scenes/name_select.tscn");
		}
	}

	void OnPauseButtonPressed()
	{
		OpenConfirmationWindow();
	}

	void OnContinueButtonPressed()
	{
		cwanim.Play("CW Close");
	}

	void OnSaveAndReturnButtonPressed()
	{
		GetTree().ChangeSceneToFile("Scenes/start_screen.tscn");
	}

	void OnCWButtonPressed()
	{
		cwanim.Play("CW Close");
	}

	void OnCWYesButtonPressed()
	{
		GetTree().ChangeSceneToFile("Scenes/scene_1.tscn");
	}

	void OnCWNoButtonPressed()
	{
		cwanim.Play("CW Close");
	}

	void OnCWAnimationFinished(StringName animName)
	{
		if (animName == "CW Close")
		{
			cw.Visible = false;
		}
	}

	void OpenConfirmationWindow()
	{
		cw.Visible = true;
		cwanim.Play("CW Open");
	}
}
