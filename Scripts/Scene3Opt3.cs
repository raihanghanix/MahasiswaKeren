using Godot;
using System;

public partial class Scene3Opt3 : Control
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
		dialog.SetDialogText($"Narator", $"Kamu belajar ngoding sampai siang.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Sekarang apa yang akan kamu lakukan?");
		}
		if (count == 2)
		{
			options.ShowBoxes();
			options.SetButtonText("Tidur sampai sore", "Lanjut merapikan barang-barangmu", "Cari angin sebentar", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_4_opt_1.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_4_opt_2.tscn", 0, 0, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_4_opt_3.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_4_opt_4.tscn", 0, 0, 0, 0);
		}
	}
}
