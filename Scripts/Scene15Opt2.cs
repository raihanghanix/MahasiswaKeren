using Godot;
using System;

public partial class Scene15Opt2 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Kantin.png");
		dialog.SetDialogText($"Narator", $"Kamu menyantap makanan yang telah dihidangkan.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Eh btw, ada yang mau ikut kerja sambilan gak? Tempat kerjaku lagi buka lowongan.");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Yang `Rumah Melon` itu ya?");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Iya.");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kuliah.png");
			dialog.SetDialogText($"Akhdan", $"Aku gak bisa ikut.");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Aku juga, tau sendiri kegiatanku ngapain.");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Kamu gimana, {MySingleton.playerName}?");
		}
		if (count == 7)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Boleh tuh, aku mau ikut!", "Oke! Habis ini langsung berangkat", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_16.tscn", 0, 0, 12, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_16.tscn", 0, 0, 12, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_15_opt_1.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_15_opt_1.tscn", 0, 0, 0, 0); 
		}
	}
}
