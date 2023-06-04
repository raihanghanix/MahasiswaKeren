using Godot;
using System;

public partial class Menu : Control
{
	int selection = 0;

	Control cw;
	AnimationPlayer cwanim;

	public override void _Ready()
	{
		Size = new Vector2(1280, 720);

		cw = GetNode<Control>("ConfirmationWindow");
		cwanim = GetNode<AnimationPlayer>("ConfirmationWindow/CWAnimation");
		cw.Visible = false;
	}

	public override void _Process(double delta)
	{
		var cwMesasge = GetNode<Label>("ConfirmationWindow/Panel/Message");

		if (selection == 1)
		{
			cwMesasge.Text = "Apakah kamu ingin memulai game baru?";
		}
		else if (selection == 2)
		{
			cwMesasge.Text = "Apakah kamu ingin memulai tutorial?";
		}
		else if (selection == 3)
		{
			cwMesasge.Text = "Apakah kamu ingin keluar dari game?";
		}

		if (Input.IsActionPressed("ui_cancel"))
		{
			cwanim.Play("CW Close");
		}
	}

	void OnPlayButtonPressed()
	{
		selection = 1;
		OpenConfirmationWindow();
	}

	void OnTutorialButtonPressed()
	{
		selection = 2;
		OpenConfirmationWindow();
	}

	void OnExitButtonPressed()
	{
		selection = 3;
		OpenConfirmationWindow();
	}

	void OnCWButtonPressed()
	{
		cwanim.Play("CW Close");
	}

	void OnCWYesButtonPressed()
	{
		if (selection == 1)
		{
			GetTree().ChangeSceneToFile("Scenes/name_select.tscn");
		}
		else if (selection == 2)
		{
			GetTree().ChangeSceneToFile("Scenes/tutorial_scene.tscn");
		}
		else if (selection == 3)
		{
			GetTree().Quit();
		}
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
