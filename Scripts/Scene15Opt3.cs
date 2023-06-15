using Godot;
using System;

public partial class Scene15Opt3 : Control
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
		MySingleton.hasBecomeCommitte = true;

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

		bg.SetBackground($"{MySingleton.backgroundPath}/Gedung utama.png");
		dialog.SetDialogText($"Narator", $"Kamu mendatangi gedung utama dan mendaftar.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
	        dialog.SetDialogText($"Narator", $"Kamu berhasil menjadi anggota panitia untuk pentas seni yang di adakan di fakultasmu.");
		}
		if (count == 2)
		{
			Button button = GetNode<Button>("Button");

			animationPlayer.Play("Transition");
		} 
	}

	void OnAnimationFinished(StringName animName)
	{
		if (animName == "Transition" && MySingleton.hasPrologScene)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_15_special.tscn");
		} 
		else if (animName == "Transition")
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_17.tscn");
		}
	}
}
