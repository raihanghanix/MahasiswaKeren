using Godot;
using System;

public partial class Scene4Opt1 : Control
{
	int count = 0;
	int selection = 0;

	BG bg;
	Character character;
	Dialog dialog;
	Options options;
	Paramater paramater;

	public override void _Ready()
	{
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
		dialog.SetDialogText($"Narator", $"Kamu tidur dikamarmu, dengan suasana yang tenang dikosanmu kualitas tidurmu meningkat dan membuatmu tertidur hingga sore dengan sangat nyeyak yang membuatmu tidur seperti orang yang sedang koma.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_5.tscn");
		}
	}
}
