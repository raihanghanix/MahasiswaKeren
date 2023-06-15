using Godot;
using System;

public partial class Scene20C : Control
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
		dialog.SetDialogText($"{MySingleton.playerName}", $"Eh Kak Fitri? Apa kabar?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Eh {MySingleton.playerName} sehat, kamu habis merathon ya?");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Hehe iya kak, lumayan kan untuk meningkatkan kebugaran tubuh.");
		}
		if (count == 3)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Wih rajin ya kamu! *Tersenyum*");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"(Aduh, Ya Tuhan! Damage senyumnya pedes banget!)");
		}
		if (count == 5)
		{
			dialog.SetDialogText($"Narator", $"Setelah itu Fitri meninggalkan Indoapril, kamupun juga segera membayar minumanmu dan langsung pulang.");
		}
		if (count == 6)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_21.tscn");
		}
	}
}
