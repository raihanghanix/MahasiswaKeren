using Godot;
using System;

public partial class Scene14B : Control
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
			dialog.SetDialogText($"Narator", $"Dosen pergi meniggalkan ruangan.");
		}
		if (count == 3)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Aku ke kantin dulu.");
		}
        if (count == 4)
		{
            character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kuliah.png");
			dialog.SetDialogText($"Akhdan", $"Aku juga. Lagi males masak.");
		}
        if (count == 5)
		{
            character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Sabrian kuliah.png");
			dialog.SetDialogText($"Sabrian", $"Aku langsung pulang.");
		}
        if (count == 6)
		{
            character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Ghani kuliah.png");
			dialog.SetDialogText($"Ghani", $"Aku juga.");
		}
        if (count == 7)
		{
            character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Aku ikut ke kantin.");
		}
        if (count == 8)
		{
			dialog.SetDialogText($"Arif", $"Kamu gimana?");
		}
        if (count == 9)
		{
        	character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Langsung pulang aja", "Makan dulu di kantin", "Aku mau daftar panitia Pensi tadi", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_15_opt_1.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_15_opt_2.tscn", 0, 0, -3, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_15_opt_3.tscn", 0, 10, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_14B.tscn", 0, 0, 0, 0); 
		}        
	}
}
