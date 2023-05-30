using Godot;
using System;

public partial class Dialog : Node2D
{
	public static Panel dialogBox { get; set; }
	public static Panel charaName { get; set; }
	public static Label dialogBoxLabel { get; set; }
	public static Label charaNameLabel { get; set; }

	public override void _Ready()
	{
		dialogBox = GetNode<Panel>("DialogBox");
		charaName = GetNode<Panel>("CharaName");
		dialogBoxLabel = GetNode<Label>("DialogBox/DialogBoxLabel");
		charaNameLabel = GetNode<Label>("CharaName/CharaNameLabel");
	}
}
