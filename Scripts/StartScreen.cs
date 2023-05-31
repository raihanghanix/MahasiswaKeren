using Godot;
using System;

public partial class StartScreen : Control
{
	Control container, menu;
	Button startButton;
	AnimationPlayer anim;

	public override void _Ready()
	{
		container = GetNode<Control>("Container");
		menu = GetNode<Control>("Menu");
		startButton = GetNode<Button>("Container/StartButton");
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	private void OnStartButtonPressed()
	{
		anim.Play("MoveMenus");
	}
}
