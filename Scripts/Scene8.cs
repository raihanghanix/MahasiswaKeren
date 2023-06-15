using Godot;
using System;

public partial class Scene8 : Control
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
		character.SetCharacter($"{MySingleton.characterPath}/Dosen.png");
		dialog.SetDialogText($"Dosen", $"Hari ini saya cukupkan sampai disini. Jangan lupa buat kelompok dan diskusikan ide projectnya.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Dosen keluar dari Lab.");
		}
		if (count == 2)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Untuk kelompoknya seperti biasa kita berenam, nanti malam kita bahas di grupchat.");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kuliah.png");
			dialog.SetDialogText($"Akhdan", $"Katsu?");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Katsu.png");
			dialog.SetDialogText($"6 Manusia Taat", $"Gas!");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Kamu gimana?");
		}
		if (count == 6)
		{
			options.ShowBoxes();
			options.SetButtonText("Ayo aja gue mah", "Aku skip, hemat uang", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_9.tscn", 0, 5, -5, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_10.tscn", 0, -3, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_8.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_8.tscn", 0, 0, 0, 0);
		}
	}
}
