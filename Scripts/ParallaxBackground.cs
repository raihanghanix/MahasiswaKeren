using Godot;
using System;

public partial class ParallaxBackground : Godot.ParallaxBackground
{
	float scrollingSpeed = 175f;

	public override void _Ready()
	{
		for (int x = 0; x < 10; x++) GD.Print(x);
	}
	
	public override void _Process(double delta)
	{
		ScrollOffset += new Vector2(-scrollingSpeed * (float)delta, 0);
		// GD.Print(ScrollOffset.X);
	}
}
