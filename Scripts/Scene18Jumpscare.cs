using Godot;
using System;

public partial class Scene18Jumpscare : Control
{
	int count = 0;
	int selection = 0;

	BG bg;
	Character character;
	Dialog dialog;
	Options options;
	Paramater paramater;
	AnimationPlayer animationPlayer;
	Timer timer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		timer = GetNode<Timer>("Timer");

		bg = (BG)GD.Load<PackedScene>("res://Scenes/bg.tscn").Instantiate();
		character = (Character)GD.Load<PackedScene>("res://Scenes/character.tscn").Instantiate();
		dialog = (Dialog)GD.Load<PackedScene>("res://Scenes/dialog.tscn").Instantiate();
		options = (Options)GD.Load<PackedScene>("res://Scenes/options.tscn").Instantiate();
		paramater = (Paramater)GD.Load<PackedScene>("res://Scenes/paramater.tscn").Instantiate();

		AddChild(bg);
		AddChild(character);
		AddChild(dialog);
		AddChild(options);
		AddChild(paramater);

		bg.SetBackground($"{MySingleton.backgroundPath}/Black.png");
		dialog.SetDialogText($"{MySingleton.playerName}", $"SIAPA IT-");
		options.HideBoxes();

		count = 0;
		timer.Start();
	}

    public override void _Process(double delta)
    {
        if (dialog.textAnimCompleted)
		{
			dialog.Hide();
			paramater.Hide();
			bg.SetBackground($"{MySingleton.backgroundPath}/Jumpscare.png");
		}
    }

	void OnTimerTimeout()
	{
		animationPlayer.Play("JumpscareFinished");
	}

	void OnAnimationFinished(StringName animName)
	{
		if (animName == "JumpscareFinished") GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/main_menu.tscn");
	}
}
