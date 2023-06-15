using Godot;
using System;

public partial class Scene3Opt1 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Rumah ibu kost.png");
		character.SetCharacter($"{MySingleton.characterPath}/Ibu kost.png");
		dialog.SetDialogText($"Ibu Kost", $"Mas {MySingleton.playerName} sudah sampai ya?");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Hehe iya bu, tadi barusan aja sampai naik Travel Ratu bu, berangkat tadi malam.");
		}
		if (count == 2)
		{
			dialog.SetDialogText($"Narator", $"Kamu berbincang dengan ibu kost.");
		}
		if (count == 3)
		{
			dialog.SetDialogText($"Narator", $"Setelah berbincang selama 30 menit, kamu kembali ke kos.");
		}
		if (count == 4)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_3_opt_2.tscn");
		}
	}
}
