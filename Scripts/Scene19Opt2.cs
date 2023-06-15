using Godot;
using System;

public partial class Scene19Opt2 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Ruang tengah kost.png");
		dialog.SetDialogText($"Narator", $"Kamu ke ruang tengah yang ada di kos lalu bertemu dengan Iqbal dan Akhdan.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Pagi Bal, Dan.");
		}
		if (count == 2)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kost 1.png");
			dialog.SetDialogText($"Iqbal", $"Pagi {MySingleton.playerName} *sambil bermain Heroes Legends*");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan gitar.png");
			dialog.SetDialogText($"Akhdan", $"Pagi {MySingleton.playerName} *sambil bermain gitar*");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"{MySingleton.playerName}", $"Iqbal, mabar kuy!");
		}
		if (count == 5)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kost 1.png");
			dialog.SetDialogText($"Iqbal", $"Ayo aja gue mah!");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Kamu duduk bersama mereka dan menghabiskan waktu bersama.");
		}
		if (count == 7)
		{
			if (MySingleton.hasBecomeCommitte)
			{
				GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_20_special.tscn");
			}
			else if (!MySingleton.hasBecomeCommitte)
			{
				GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_21.tscn");
			}
		}
	}
}
