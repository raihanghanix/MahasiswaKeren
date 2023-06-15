using Godot;
using System;

public partial class Scene15Opt1 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Parkir.png");
		character.SetCharacter($"{MySingleton.characterPath}/Iqbal kuliah.png");
		dialog.SetDialogText($"Iqbal", $"Eh, daripada langsung pulang gak ngapa-ngapain, gimana kalo ikut aku kerja sambilan, mumpung lagi nyari satu orang buat direkrut.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.RemoveCharacter();
			options.ShowBoxes();
			options.SetButtonText("Boleh juga tuh. Dimana?", "Oke. Gas!", "", "");
			options.SetValues1($"{MySingleton.scenePath}/scene_16.tscn", 0, 0, 12, 0);
			options.SetValues2($"{MySingleton.scenePath}/scene_16.tscn", 0, 0, 12, 0);
			options.SetValues3($"{MySingleton.scenePath}/scene_15_opt_1.tscn", 0, 0, 0, 0);
			options.SetValues4($"{MySingleton.scenePath}/scene_15_opt_1.tscn", 0, 0, 0, 0); 
		}
	}
}
