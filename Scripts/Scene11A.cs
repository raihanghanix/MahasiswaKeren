using Godot;
using System;

public partial class Scene11A : Control
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
		dialog.SetDialogText($"Narator", $"Kamu tertidur sampai maghrib.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			bg.SetBackground($"{MySingleton.backgroundPath}/Membuka HP.png");
			dialog.SetDialogText($"Narator", $"Kamu bangun dan melihat banyak notifikasi panggilan tak terjawab di hp-mu.");
			sprite2D.Visible = true;
		}
		if (count == 2)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Duh... Ada zoom dadakan ternyata, Iqbal sama Akhdan belum pulang apa ya? gak ada yang ngetokin pintu kamar soalnya. Ya udahlah toh baru sekali.");
			sprite2D.Visible = false;
		}
		if (count == 3)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_12.tscn");
		}
	}
}
