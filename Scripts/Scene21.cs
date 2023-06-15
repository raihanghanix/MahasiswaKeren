using Godot;
using System;

public partial class Scene21 : Control
{
	int count = 0;
	int selection = 0;

	BG bg;
	Character character;
	Dialog dialog;
	Options options;
	Paramater paramater;
	AnimationPlayer animationPlayer;
	Button button;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		button = GetNode<Button>("Button");

		bg = (BG)GD.Load<PackedScene>("res://Scenes/bg.tscn").Instantiate();
		character = (Character)GD.Load<PackedScene>("res://Scenes/character.tscn").Instantiate();
		dialog = (Dialog)GD.Load<PackedScene>("res://Scenes/dialog.tscn").Instantiate();
		options = (Options)GD.Load<PackedScene>("res://Scenes/options.tscn").Instantiate();
		paramater = (Paramater)GD.Load<PackedScene>("res://Scenes/paramater.tscn").Instantiate();

		// AddChild(bg);
		// AddChild(character);
		// AddChild(dialog);
		// AddChild(options);
		// AddChild(paramater);

		// options.HideBoxes();
		// animationPlayer.Play("Transition");
		count = 0;
	}

	void OnAnimationFinished(StringName animName)
	{
		if (animName == "SceneTransition") 
		{
			animationPlayer.Play("Transition");
		}
	}

	void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/main_menu.tscn");
	}
}
