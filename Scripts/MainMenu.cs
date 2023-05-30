using Godot;
using System;

public partial class MainMenu : Node2D
{
	Label label, playerNameLabel;
	string playerName;

	public override void _Ready()
	{
		playerNameLabel = GetNode<Label>("PlayerName");

		// Check if the NameSelect.PlayerName is not null
		if (NameSelect.PlayerName != null)
        {
            playerName = NameSelect.PlayerName;
            playerNameLabel.Text = playerName;
        }
        else
        {
            playerName = "John Doe";
            playerNameLabel.Text = playerName;
        }
	}

	private void _on_button_play_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/scene_1.tscn");
	}

	private void _on_button_tutorial_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/tutorial_scene.tscn");
	}

	private void _on_button_keluar_pressed()
	{
		GetTree().Quit();
	}
}
