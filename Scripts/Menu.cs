using Godot;
using System;

public partial class Menu : Control
{
	public override void _Ready()
	{

	}

	private void OnPlayButtonPressed()
	{
		GetTree().ChangeSceneToFile("Scenes/name_select.tscn");
	}

	private void OnTutorialButtonPressed()
	{
		GetTree().ChangeSceneToFile("Scenes/tutorial_scene.tscn");
	}

	private void OnExitButtonPressed()
	{
		GetTree().Quit();
	}
}
