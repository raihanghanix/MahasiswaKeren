using Godot;
using System;

public partial class StartScreen : Node2D
{
	Button btn;

	public override void _Ready()
	{
		btn = GetNode<Button>("Button");
	}

	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/name_select.tscn");
	}
}
