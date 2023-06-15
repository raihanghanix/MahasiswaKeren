using Godot;
using System;

public partial class Scene6 : Control
{
	int count = 0;
	int selection = 0;

	BG bg;
	Character character;
	Dialog dialog;
	Options options;
	Paramater paramater;
	AnimationPlayer animationPlayer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

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

		bg.SetBackground($"{MySingleton.backgroundPath}/Kamar kost.png");
		dialog.SetDialogText($"Narator", $"Setelah hari yang panjang ini kamu memutuskan untuk mengakhiri hari ini dan pergi kekasur mu untuk tidur.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Waktunya tidur.");
		}
		if (count == 2)
		{
			animationPlayer.Play("Transition");
		}
	}

	void OnAnimationFinished(StringName animName)
	{
		if (animName == "Transition") GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_7.tscn");
	}
}
