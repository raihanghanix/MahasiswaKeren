using Godot;
using System;

public partial class ConfirmationWindow : Control
{
	public static string scenePath { get; set; }
	AnimationPlayer anim;
	Label message;

	public override void _Ready()
	{
		anim = GetNode<AnimationPlayer>("CWAnimation");
		message = GetNode<Label>("Panel/Message");

		Visible = false;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
		{
			Close();
		}
	}

	public void OnButtonPressed()
	{
		Close();
	}

	public void OnYesButtonPressed()
	{
		if (MySingleton.selection == 1)
		{
			GD.Print("Continue");
		}
		else if (MySingleton.selection == 2)
		{
			GetTree().ChangeSceneToFile("res://Scenes/name_select.tscn");
		}
		else if (MySingleton.selection == 3)
		{
			GetTree().ChangeSceneToFile("res://Scenes/tutorial_scene.tscn");
		}
		else if (MySingleton.selection == 4)
		{
			GetTree().Quit();
		}
		else if (MySingleton.selection == 5)
		{
			GetTree().ChangeSceneToFile("res://Scenes/main_menu.tscn");
		}
	}

	public void OnNoButtonPressed()
	{
		Close();
	}

	public void Open()
	{
		Visible = true;
		anim.Play("CW Open");
	}

	public void Close()
	{
		anim.Play("CW Close");
	}

	public void OnCWAnimationFinished(StringName animName)
	{
		if (animName == "CW Close") Visible = false;
	}

	public void SetMessage(string text = "Lorem Ipsum")
	{
		message.Text = text;
	}
}
