using Godot;
using System;

public partial class Scene20B : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Indoapril.png");
		dialog.SetDialogText($"{MySingleton.playerName}", $"Kak Fitri disini juga?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Pagi {MySingleton.playerName}, abis maraton ya?");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Iya kak, olahraga...");
		}
		if (count == 3)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Rajinnya... Btw gimana kegiatan di kepanitiaan?");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Belum ada yang spesial sih kak, tapi temen ku jadi tambah banyak.");
		}
		if (count == 5)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Gitu ya... *Tersenyum* semangat ya!");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"(Duh senyumnya nembus jantung) Siap kak!");
		}
		if (count == 7)
		{
			dialog.SetDialogText($"Narator", $"Setelah itu Fitri meninggalkan Indoapril, kamu pun juga segera membayar minumanmu dan langsung pulang.");
		}
		if (count == 8)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_21.tscn");
		}
	}
}
