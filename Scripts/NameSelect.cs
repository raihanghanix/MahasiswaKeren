using Godot;
using System;

public partial class NameSelect : Control
{
	public static string PlayerName { get; set; }

	Control cw;
	AnimationPlayer cwanim;
	Label cwMesasge;
	LineEdit lineEdit;

	public override void _Ready()
	{
		cw = GetNode<Control>("ConfirmationWindow");
		cwMesasge = GetNode<Label>("ConfirmationWindow/Panel/Message");
		cwanim = GetNode<AnimationPlayer>("ConfirmationWindow/CWAnimation");
		lineEdit = GetNode<LineEdit>("LineEdit");
	}

	public override void _Process(double delta)
	{
		MySingleton.SetPlayerName(lineEdit.Text);

		if (Input.IsActionPressed("ui_cancel"))
		{
			cwanim.Play("CW Close");
		}
	}

	void OnNextButtonPressed()
	{
		if (MySingleton.playerName.Length > 0)
		{
		cwMesasge.Text = $"Apakah kamu sudah yakin dengan nama mu?\n {MySingleton.playerName}";
		OpenConfirmationWindow();
		}
	}

	void OnBackButtonPressed()
	{
		GetTree().ChangeSceneToFile("Scenes/main_menu.tscn");
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
