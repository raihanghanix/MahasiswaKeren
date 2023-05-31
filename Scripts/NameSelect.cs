using Godot;
using System;

public partial class NameSelect : Node2D
{
	Button btn;
	LineEdit inputField;
	ConfirmationDialog confirmation;
	public static string PlayerName { get; set; }

	public override void _Ready()
	{
		btn = GetNode<Button>("Panel/Button");
		inputField = GetNode<LineEdit>("LineEdit");
		confirmation = GetNode<ConfirmationDialog>("ConfirmationDialog");

		confirmation.Visible = false;
	}

	private void _on_button_pressed()
	{
		PlayerName = inputField.Text;

		if (PlayerName.Length == 0)
		{
			GD.Print("Nama tidak boleh kosong!");
		}
		else
		{
			confirmation.Visible = true;
		}
	}

	private void _on_button_2_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/start_screen.tscn");
	}

	private void _on_confirmation_dialog_confirmed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/scene_1.tscn");
	}
}
