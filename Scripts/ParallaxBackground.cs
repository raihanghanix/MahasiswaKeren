using Godot;
using System;

public partial class ParallaxBackground : Godot.ParallaxBackground
{
	float scrollingSpeed = 175f;

	public override void _Process(double delta)
	{
		ScrollOffset += new Vector2(-scrollingSpeed * (float)delta, 0);
	}
}
