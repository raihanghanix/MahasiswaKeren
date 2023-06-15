using Godot;
using System;

public partial class Scene18Opt2 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Layar laptop.png");
		dialog.SetDialogText($"Narator", $"Kamu menonton video tutorial ngoding sampai jam 2 malam.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Dikala kamu sedang belajar, kamu mendengar suara aneh diluar.");
		}
		if (count == 2)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Suara apa itu?");
		}
		if (count == 3)
		{
			options.ShowBoxes();
			options.SetButtonText("Cari tahu", "Mending tidur", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_18_jumpscare.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_18_opt_1.tscn", 0, 0, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_18_opt_2.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_18_opt_2.tscn", 0, 0, 0, 0); 
		}
	}
}
