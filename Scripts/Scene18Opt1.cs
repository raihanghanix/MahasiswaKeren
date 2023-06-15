using Godot;
using System;

public partial class Scene18Opt1 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Halaman depan kost.png");
		dialog.SetDialogText($"Narator", $"Kamu tidur lelap hingga pagi.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Hari minggu yang indah, hari yang cocok buat...");
		}
		if (count == 2)
		{
			options.ShowBoxes();
			options.SetButtonText("Jalan pagi", "Main game seharian", "Ngoding", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_19_opt_1.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_19_opt_2.tscn", -3, 10, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_19_opt_3.tscn", 10, -5, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_18_opt_1.tscn", 0, 0, 0, 0); 
		}
	}
}
