using Godot;
using System;

public partial class Scene11B : Control
{
	int count = 0;
	int selection = 0;

	BG bg;
	Character character;
	Dialog dialog;
	Options options;
	Paramater paramater;
	AnimationPlayer animationPlayer;
	Sprite2D sprite2D;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		sprite2D = GetNode<Sprite2D>("Sprite2D");

		sprite2D.Visible = false;

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

		bg.SetBackground($"{MySingleton.backgroundPath}/Kamar kost.png");
		dialog.SetDialogText($"Narator", $"Kamu memainkan smartphonemu dengan asik, *notifikasi WhatsApp \"Grup Kelas\"*");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			bg.SetBackground($"{MySingleton.backgroundPath}/Membuka HP.png");
			dialog.SetDialogText($"Dosen", $"Selamat siang nak, karena besok saya ada kegiatan dan tidak bisa melaksanakan perkuliahan maka kita ganti sore ini melalui zoom ya.");
			sprite2D.Visible = true;
		}
		if (count == 2)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Untung gak tidur, bisa-bisa gak ikutan zoom ntar.");
			sprite2D.Visible = false;
		}
		if (count == 3)
		{
			dialog.SetDialogText($"Narator", $"Kamu join zoom dan mengikuti perkuliahan.");
			sprite2D.Visible = false;
		}
		if (count == 4)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_12.tscn");
		}
	}
}
