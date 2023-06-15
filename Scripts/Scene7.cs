using Godot;
using System;

public partial class Scene7 : Control
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
		dialog.SetDialogText($"{MySingleton.playerName}", $"Sudah waktunya kembali ke kehidupan kampus.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Kamu melihat teman-temanmu yang sedang asik mengobrol dan menghampiri mereka.");
		}
		if (count == 2)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Jadi semester 5 ini kalian ada rencana ikut program MBKM?");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Ghani kuliah.png");
			dialog.SetDialogText($"Ghani", $"Aku mungkin bakal ikut Studi Independen sih.");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kuliah.png");
			dialog.SetDialogText($"Akhdan", $"Aku lebih tertarik PMM.");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Aku belum kepikiran, mungkin gak bakal ikut.");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Sabrian kuliah.png");
			dialog.SetDialogText($"Sabrian", $"Aku juga tertarik sama PMM.");
		}
		if (count == 7)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Kayanya cuma aku yang milih magang. Kamu gimana {MySingleton.playerName}?");
		}
		if (count == 8)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Aku juga tertarik ikut magang", "Aku tertarik sama PMM biar bisa ke kampus lain", "Mungkin Studi Independen", "Yahh belum tau juga sih");
			options.SetValues1($"{MySingleton.scenePath}/scene_8.tscn", 5, 0, 5, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_8.tscn", 5, 5, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_8.tscn", 10, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_8.tscn", 0, 0, 0, 0);
		}
	}
}
