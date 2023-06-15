using Godot;
using System;

public partial class Scene12 : Control
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
		dialog.SetDialogText($"Narator", $"Kamu yang sedang berkumpul dengan teman-temanmu dihampiri oleh seorang pengurus himpunan mahasiswa.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Pengurus HIMA.png");
			dialog.SetDialogText($"Pengurus HIMA", $"Hai kalian... Himpunan kita lagi buka lowongan buat Panitia Pentas seni kalian mau coba daftar?");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Sabrian kuliah.png");
			dialog.SetDialogText($"Sabrian", $"Aku skip, mau fokus ngoding.");
		}
		if (count == 3)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Ghani kuliah.png");
			dialog.SetDialogText($"Ghani", $"Sama.");
		}
		if (count == 4)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
			dialog.SetDialogText($"Iqbal", $"Aku ada kegiatan lain, jadi nggak dulu.");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Akhdan kuliah.png");
			dialog.SetDialogText($"Akhdan", $"Liat kondisi dulu, tapi lebih ke nggak tertarik sih.");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Arif kuliah.png");
			dialog.SetDialogText($"Arif", $"Aku sibuk mengkurir jadi tidak bisa.");
		}
		if (count == 6)
		{
			character.RemoveCharacter();
			character.SetCharacter($"{MySingleton.characterPath}/Pengurus HIMA.png");
			dialog.SetDialogText($"Pengurus HIMA", $"Hmm... Bagaimana dengan kamu? *menunjuk ke arah pemain*");
		}
		if (count == 7)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Boleh juga, nanti aku daftar. Gimana caranya?", "Hmm... Pikir-pikir dulu", "Skip juga", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_13A.tscn", 0, 10, 0, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_13B.tscn", 0, -3, 0, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_13B.tscn", 0, -3, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_12.tscn", 0, 0, 0, 0);
		}
	}
}
