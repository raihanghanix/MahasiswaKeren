using Godot;
using System;

public partial class BG : Control
{
	Sprite2D sprite2D;

	public override void _Ready()
	{
		sprite2D = GetNode<Sprite2D>("Sprite2D");
	}

	public void SetBackground(string path)
	{
		var texture = (Texture2D)GD.Load(path);
		sprite2D.Texture = texture;
	}
}
