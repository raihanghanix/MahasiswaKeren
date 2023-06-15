using Godot;
using System;

public partial class Scene3Opt4 : Control
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
		dialog.SetDialogText($"Narator", $"Kamu berkeliling kota dengan menggunakan motormu dan mendapatkan mood yang baik selama berjalan jalan.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Apa yang akan kamu lakukan sekarang?");
		}
		if (count == 2)
		{
			options.ShowBoxes();
			options.SetButtonText("Lansung pulang ke kos", "Mampir ke toko untuk membeli jajan dan dibawa pulang", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_5.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_4_special.tscn", 0, 0, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_4_opt_4.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_4_opt_4.tscn", 0, 0, 0, 0);
		}
	}
}
