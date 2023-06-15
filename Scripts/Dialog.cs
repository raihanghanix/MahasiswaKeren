using Godot;
using System;

public partial class Dialog : Control
{
	public bool textAnimCompleted = false;	

	Panel dialogBox, nameBox;
	Label nameText;
	RichTextLabel dialogText;

	AnimationPlayer animationPlayer;

	public override void _Ready()
	{
		dialogBox = GetNode<Panel>("DialogBox");
		dialogText = GetNode<RichTextLabel>("DialogBox/DialogBoxText");
		nameBox = GetNode<Panel>("CharaNameBox");
		nameText = GetNode<Label>("CharaNameBox/CharaNameText");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void ShowNameBox()
	{
		nameBox.Visible = true;
	}

	public void HideNameBox()
	{
		nameBox.Visible = false;
	}

	public void SetNameText(string name)
	{
		nameText.Text = name;
	}

	public void SetDialogText(string speaker, string text)
	{
		if (speaker == "Narator")
		{
			HideNameBox();
		}
		else
		{
			ShowNameBox();
			SetNameText(speaker);	
		}
		dialogText.Text = text;
		animationPlayer.Play("TextAnim");
	}

	public void SetDialogText(string text)
	{
		dialogText.Text = text;
		animationPlayer.Play("TextAnim");
	}

	public void OnTextAnimFinished(StringName animName)
	{
		if(animName == "TextAnim") textAnimCompleted = true;
	}
}
