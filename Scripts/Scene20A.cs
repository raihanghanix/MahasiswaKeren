using Godot;
using System;

public partial class Scene20A : Control
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
		dialog.SetDialogText($"{MySingleton.playerName}", $"Kakak kan yang waktu itu yang open rekrutmen Panitia Pensi ya?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Oh... Kamu yang waktu itu di gazebo ya? Abis lari pagi?");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Hehe... Iya kak.");
		}
		if (count == 3)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"*Tersenyum* Rajin yaa...");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"(Duh senyumnya!)");
		}
		if (count == 5)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"Fitri", $"Oiya... Kita belum kenalan kan? Nama kakak Fitri. Mohon kerja samanya saat pentas seni fakultas nanti ya! *tersenyum*");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Aku {MySingleton.playerName}. Ya kak saya juga mohon bantuan nya!");
		}
		if (count == 7)
		{
			dialog.SetDialogText($"Narator", $"Setelah itu Fitri pergi, dan kamu pun juga berjalan pulang ke kos.");
		}
		if (count == 8)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_21.tscn");
		}
	}
}
