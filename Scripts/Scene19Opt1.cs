using Godot;
using System;

public partial class Scene19Opt1 : Control
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

		bg.SetBackground($"{MySingleton.backgroundPath}/Jalan raya.png");
		dialog.SetDialogText($"Narator", $"Setelah merasa cukup olahraga pagi, kamu memutuskan untuk membeli minuman di Indoapril.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Setelah masuk ke dalam toko, kamu melihat sosok yang tidak asing.");
		}
		if (count == 2)
		{
			if (MySingleton.hasPrologScene)
			{
				GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_20C.tscn");
			}
			else if (MySingleton.hasPrologScene && MySingleton.hasBecomeCommitte)
			{
				GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_20B.tscn");
			}
			else if (!MySingleton.hasPrologScene && !MySingleton.hasBecomeCommitte)
			{
				GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_20A.tscn");
			}
			else
			{
				GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_20A.tscn");
			}
		}
	}
}
