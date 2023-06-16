using Godot;
using System;

public partial class Scene13A : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Gazebo.png");
		character.SetCharacter($"{MySingleton.characterPath}/Pengurus HIMA.png");
		dialog.SetDialogText($"Pengurus HIMA", $"Kamu bisa pergi ke gedung utama jam 2 siang nanti ya. Kalau sebelum jam 2 ada yang mau ditanyakan kamu bisa bertanya ke saya melalui WhatsApp.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Kamu bertukar nomor WhatsApp dengannya. Setelah itu pengurus HIMA tersebut beranjak pergi.");
		}
		if (count == 2)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kuliah.png");
			dialog.SetDialogText($"Akhdan", $"Aku mencium aroma konspirasi!");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Betul tuh, tumben banget ini orang mau ikut organisasi.");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Dia seperti terkena Genjutsu (hipnotis) sales Oddo.");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Sabrian kuliah.png");
			dialog.SetDialogText($"Sabrian", $"Gampang banget kegoda kamu bang.");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Ghani kuliah.png");
			dialog.SetDialogText($"Ghani", $"Awokwkwkwk.");
		}
		if (count == 7)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Jadi ini hasil tugas kelompok kita sudah selesai dan sebentar lagi dipresentasikan, ada yang mau ditambah?");
		}
		if (count == 8)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Cukup", "Tambahkan beberapa hal", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_14A.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_14A.tscn", 4, 0, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_13A.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_13A.tscn", 0, 0, 0, 0);
		}		
	}
}
