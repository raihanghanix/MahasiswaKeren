using Godot;
using System;

public partial class Scene15Special : Control
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
		dialog.SetDialogText($"Narator", $"Sesaat setelah kamu keluar dari ruangan pertemuan di gedung utama terdengar suara seorang wanita yang memanggil nama mu dari samping.");
		options.HideBoxes();

		count = 0;
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
	        dialog.SetDialogText($"Fitri", $"Eh, kamu yang kemarin udah ngebantuin aku makasih banget ya hampir aja aku kecopetan. Kenalin aku Fitri!");
		}
		if (count == 2)
		{
			character.RemoveCharacter();
	        dialog.SetDialogText($"{MySingleton.playerName}", $"Ah kakak yang waktu itu ya. Ehehe sama-sama kak, kebetulan aja saya juga mau mampir beli minum waktu itu, nama saya {MySingleton.playerName}.");
		}
		if (count == 3)
		{
	        dialog.SetDialogText($"Narator", $"Setelah berbincang sebentar dengan Kak Fitri akhirnya Kak Fitri pamit karna masi ada yang perlu Ia kerjakan di HIMA.");
		}
		if (count == 4)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
	        dialog.SetDialogText($"Fitri", $"Kalo gitu aku pamit dan salam kenal ya {MySingleton.playerName}!");
		}
		if (count == 5)
		{
			character.RemoveCharacter();
	        dialog.SetDialogText($"{MySingleton.playerName}", $"Ya kak, salken juga!");
		}
		if (count == 6)
		{
	        dialog.SetDialogText($"Narator", $"Fitri pun pergi.");
		}
		if (count == 7)
		{
	        GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_17.tscn");
		}
	}
}
