using Godot;
using System;

public partial class Scene16 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Rumah melon.png");
		character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
		dialog.SetDialogText($"Iqbal", $"Pak ini ada temen yang mau kerja sambilan juga disini, lowongannya masih buka kan?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Pemiliki Toko", $"Oh iya, masih buka nak Iqbal. Mana temennya yang mau ngelamar?");
		}
		if (count == 2)
		{
			dialog.SetDialogText($"Narator", $"Kamu memperkenalkan diri kepada pemilik toko.");
		}
		if (count == 3)
		{
			dialog.SetDialogText($"Narator", $"Kamu dan pemilik toko berbincang mengenai pekerjaan, jadwal dan bayaran yang akan kamu terima.");
		}
		if (count == 4)
		{
			dialog.SetDialogText($"Narator", $"Kamu menyetujuinya dan menjadi pegawai paruh waktu di toko tersebut.");
		}
		if (count == 5)
		{
			dialog.SetDialogText($"Narator", $"Setelah itu kamu langsung pulang.");
		}
		if (count == 6)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_17.tscn");
		}
	}
}
