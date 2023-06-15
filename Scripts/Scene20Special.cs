using Godot;
using System;

public partial class Scene20Special : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Ruang tengah kost.png");
		dialog.SetDialogText($"Narator", $"Kamu mendapat notifikasi pesan yang mana kamu dimasukan ke grup Kepanitiaan Pentas Seni Fakultas.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Seorang kakak tingkat bernama Kak Fitri memperkenalkan diri.");
		}
		if (count == 2)
		{
			dialog.SetDialogText($"Narator", $"Ia juga menjelaskan perihal pentas seni yang akan diadakan fakultas.");
		}
		if (count == 3)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_21.tscn");
		}
	}
}
