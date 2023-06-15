using Godot;
using System;

public partial class Scene14A : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Lab komputer.png");
		dialog.SetDialogText($"Narator", $"Tiap kelompok mempresentasikan ide project mereka untuk tugas akhir.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
	        character.SetCharacter($"{MySingleton.characterPath}/Dosen.png");
			dialog.SetDialogText($"Dosen", $"Baiklah, untuk 2 minggu ini tugas kalian adalah analisis apa saja kebutuhan dari sistem yang akan kalian buat.");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Dosen meniggalkan ruangan.");
		}
		if (count == 3)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Oke, mungkin besok malam kita bakal mulai kerjain tugasnya, aku balik dulu.");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Teman-teman yang lain juga ikut pulang, sementara kamu segera menuju ke gedung utama untuk mendaftar menjadi anggota himpunan.");
		}
		if (count == 5)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_15_opt_3.tscn");
		}	
	}
}
