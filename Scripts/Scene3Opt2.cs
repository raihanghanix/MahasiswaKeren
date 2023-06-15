using Godot;
using System;

public partial class Scene3Opt2 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Ruang tengah kost.png");
		dialog.SetDialogText($"Narator", $"Kamu berkumpul dengan teman kos.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kost 1.png");
			dialog.SetDialogText($"Iqbal", $"Wedeh baru nyampe nih!");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kost.png");
			dialog.SetDialogText($"Akhdan", $"Iya tuh, tumben baru nyampe.");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kost 1.png");
			dialog.SetDialogText($"Iqbal", $"Makan nih jajanan!");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Iqbal membuka bungkus jajanan.");
		}
		if (count == 5)
		{
			dialog.SetDialogText($"Narator", $"Kalian memakan jajanan bersama dan mengobrol sampai tengah hari.");
		}
		if (count == 6)
		{
			dialog.SetDialogText($"Narator", $"Kamu kembali ke kamarmu dan melanjukan merapikan barang-barang dikamar kosanmu.");
		}
		if (count == 7)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_4_opt_2.tscn");
		}
	}
}
