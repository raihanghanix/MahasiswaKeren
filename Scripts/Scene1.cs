using Godot;
using System;

public partial class Scene1 : Control
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

		MySingleton.ResetValues();
		MySingleton.hasBecomeCommitte = false;
		MySingleton.hasPrologScene = false;

		bg.SetBackground($"{MySingleton.backgroundPath}/Kamar rumah.png");
		dialog.SetDialogText($"Narator", $"Nama kamu adalah {MySingleton.playerName}, kamu adalah mahasiswa sistem informasi semester 5, dan saat ini kamu sedang bersiap siap kembali ke kosanmu setelah liburan yang tenang dan menyenangkan.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Apa yang sebaiknya ku lakukan sekarang?");
		}
		if (count == 2)
		{
			options.ShowBoxes();
			options.SetButtonText("Berbicara dengan orang tua", "Menelpon teman", "Lanjut ngoding", "Mengecek kembali barang dan persediaan");
			options.SetValues1($"{MySingleton.scenePath}/scene_2.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_2.tscn", 0, 15, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_2.tscn", 15, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_2.tscn", 0, 0, 15, 0);
		}
	}
}
