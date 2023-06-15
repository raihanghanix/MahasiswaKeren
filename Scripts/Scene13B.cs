using Godot;
using System;

public partial class Scene13B : Control
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
		dialog.SetDialogText($"Pengurus HIMA", $"Kalau kalian tiba-tiba berubah pikiran kalian bisa datang ke gedung utama jam 2 siang nanti. Jika ada yang ingin ditanyakan, kalian bisa bertanya ke ketua kelas masing-masing.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Pengurus hima tersebut pergi meninggalkan tempat kalian berada.");
		}
		if (count == 2)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Jadi ini hasil tugas kelompok kita sudah selesai dan sebentar lagi dipresentasikan, ada yang mau ditambah?");
		}
        if (count == 3)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Cukup", "Tambahkan beberapa hal", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_14B.tscn", 0, 0, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_14B.tscn", 4, 0, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_13B.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_13B.tscn", 0, 0, 0, 0);
		}	
    }
}
