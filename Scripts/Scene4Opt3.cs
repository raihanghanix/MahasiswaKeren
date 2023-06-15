using Godot;
using System;

public partial class Scene4Opt3 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Jalan raya.png");
		dialog.SetDialogText($"Narator", $"Kamu berkeliling kota dengan menggunakan motor Supra kesayanganmu.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Dikarenakan suasana yang panas disiang hari kamu memutuskan untuk mampir ke toko untuk membeli minuman.");
		}
		if (count == 2)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_4_special.tscn");
		}
	}
}
