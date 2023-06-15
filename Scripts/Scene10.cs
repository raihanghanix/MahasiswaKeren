using Godot;
using System;

public partial class Scene10 : Control
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
		dialog.SetDialogText($"{MySingleton.playerName}", $"Hmm... Enaknya ngapain ya?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			options.ShowBoxes();
			options.SetButtonText("Tidur", "Nyantai dulu gak sih", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_11A.tscn", -3, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_11B.tscn", 5, 0, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_10.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_10.tscn", 0, 0, 0, 0);
		}
	}
}
