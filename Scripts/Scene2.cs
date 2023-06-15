using Godot;
using System;

public partial class Scene2 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Halaman depan kost.png");
		dialog.SetDialogText($"{MySingleton.playerName}", $"Kamu baru saja sampai di kos, apa yang akan kamu lakukan sekarang?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			options.ShowBoxes();
			options.SetButtonText("Berbicara dengan ibu kost", "Berbicara dengan teman kost", "Lanjut belajar ngoding", "Cari angin segar");
			options.SetValues1($"{MySingleton.scenePath}/scene_3_opt_1.tscn", 0, 5, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_3_opt_2.tscn", 0, 7, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_3_opt_3.tscn", 7, -5, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_3_opt_4.tscn", 0, -5, 0, 0);
		}
	}
}
