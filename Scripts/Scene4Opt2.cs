using Godot;
using System;

public partial class Scene4Opt2 : Control
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
		dialog.SetDialogText($"Narator", $"Kamu berada di kamarmu dan merapikan barang barang yang ada didalam kamarmu.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Diantara barang-barang yang kamu rapikan kamu menemukan sebuah foto yang berisikan kamu dan teman-temanmu yang sedang berkumpul bersama dan bersenang-senang bersama.");
		}
		if (count == 2)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Foto ini masih ada ternyata, ada-ada saja ya waktu itu...");
		}
		if (count == 3)
		{
			dialog.SetDialogText($"Narator", $"Kamu melanjutkan merapikan barang di kamarmu.");
		}
		if (count == 4)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_6.tscn");
		}
	}
}
