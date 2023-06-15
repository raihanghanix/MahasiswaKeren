using Godot;
using System;

public partial class MainMenu : Node
{
    [Export] public PackedScene cwScene { get; set; }
	ConfirmationWindow cw;
	
	public override void _Ready()
	{
		MySingleton.selection = 0;
		cw = cwScene.Instantiate<ConfirmationWindow>();
		AddChild(cw);
	}

	void OnContinuePressed()
	{
		MySingleton.selection = 1;
		cw.SetMessage("Apakah kamu ingin melanjutkan permainan?");
		cw.Open();
	}

	void OnNewPressed()
	{
		MySingleton.selection = 2;
		cw.SetMessage("Apakah kamu ingin memulai permainan baru?");
		cw.Open();
	}

	void OnTutorialPressed()
	{
		MySingleton.selection = 3;
		cw.SetMessage("Apakah kamu ingin memulai tutorial?");
		cw.Open();
	}

	void OnQuitPressed()
	{	
		MySingleton.selection = 4;
		cw.SetMessage("Apakah kamu ingin keluar dari permainan?");
		cw.Open();
	}
}
