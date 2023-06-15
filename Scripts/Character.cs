using Godot;
using System;

public partial class Character : Sprite2D
{
	AnimationPlayer animationPlayer;

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void SetCharacter(string path)
	{
		if (path == null || path == "")
		{
			Texture = null;
		}
		else
		{
			Texture = null;
			var image = ResourceLoader.Load<Texture2D>(path);
			Texture = image;
			animationPlayer.Play("Slide");
		}	
	}

	public void RemoveCharacter()
	{
		animationPlayer.Play("Slide1");
	}

	void OnAnimationFinished(StringName animName)
	{
		if (animName == "Slide1") Texture = null;
	}
}
