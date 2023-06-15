using Godot;
using System;

public partial class Scene9 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Kantin.png");
		character.SetCharacter($"{MySingleton.characterPath}/Sabrian kuliah.png");
		dialog.SetDialogText($"Sabrian", $"Kak, katsunya 6 ya.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Kakak kantin.png");
			dialog.SetDialogText($"Kakak Kantin", $"Ok dek!");
		}
		if (count == 2)
		{
			dialog.SetDialogText($"Kakak Kantin", $"Minumannya apa?");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Drink Beng-beng", "Teh es manis", "Air putih", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_10.tscn", 0, 0, -4, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_10.tscn", 0, 0, -3, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_10.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_9.tscn", 0, 0, 0, 0);
		}
	}
}
