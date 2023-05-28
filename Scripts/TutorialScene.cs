using Godot;
using System;

public partial class TutorialScene : Node2D
{
	ConfirmationDialog confirmation;
	Panel tutorialBox, paramaters, dialogBox, charaName;
	Label tutorialBoxText;
	Control control;
	Button skipBtn, nextBtn;
	private int count = 0;

	public override void _Ready()
	{
		confirmation = GetNode<ConfirmationDialog>("ConfirmationDialog");
		tutorialBox = GetNode<Panel>("TutorialBox");
		paramaters = GetNode<Panel>("Parameters");
		dialogBox = GetNode<Panel>("DialogBox");
		charaName = GetNode<Panel>("CharaName");
		tutorialBoxText = GetNode<Label>("TutorialBox/Label");
		control = GetNode<Control>("Control");
		skipBtn = GetNode<Button>("TutorialBox/SkipButton");
		nextBtn = GetNode<Button>("TutorialBox/NextButton");

		tutorialBoxText.Text = "Parameter dari kiri ke kanan ada Akademis, Sosial, Keuangan, dan Cinta. Jika salah satu telah menyentuh angka 0 atau 100 Maka game akan berakhir. Setiap parameter akan memberikan ending yang berbeda.";

		confirmation.Visible = false;
	}

	private void OnSkipButtonPressed()
	{
		tutorialBox.Visible = false;
		confirmation.Visible = true;
	}

	private void OnConfirmationDialogConfirmed()
	{
		GetTree().ChangeSceneToFile("Scenes/scene_1.tscn");
	}

	private void OnConfirmationDialogCanceled()
	{
		tutorialBox.Visible = true;
		confirmation.Visible = false;
	}

	private void OnNextButtonPressed()
	{
		count++;
		if (count == 1)
		{
			tutorialBoxText.Text = "Pertanyaan akan disampaikan oleh setiap karakter. Pertanyaan dari karakter dapat berbentuk bahasa formal ataupun informal. Pertanyaan dapat memiliki makna ganda ataupun berkelanjutan, anda harus memperhatikan itu dengan baik.";
			paramaters.Modulate = new Color(0.4f, 0.4f, 0.4f);
			dialogBox.Modulate = new Color(1f, 1f, 1f);
			charaName.Modulate = new Color(1f, 1f, 1f);
		}
		else if (count == 2)
		{
			tutorialBoxText.Text = "Berdasarkan pertanyaan disampaikan, nantinya anda akan dihadapkan oleh beberapa jawaban. Setiapjawaban akan memberikan efek yang berbeda kepada nilai parameter.";
			dialogBox.Modulate = new Color(0.4f, 0.4f, 0.4f);
			charaName.Modulate = new Color(0.4f, 0.4f, 0.4f);
			control.Modulate = new Color(1f, 1f ,1f);
			skipBtn.Visible = false;
			nextBtn.Position = new Vector2(64f, 192f);
			nextBtn.Size = new Vector2(384f, 40f);
			nextBtn.Text = "Mulai Bermain!";
		}
		else 
		{
			GetTree().ChangeSceneToFile("Scenes/scene_1.tscn");
		}
	}
}
