using Godot;
using System;

public partial class Options : Control
{
	VBoxContainer vBoxContainer;
	Button b1, b2, b3, b4;
	AnimationPlayer animationPlayer;
	
	string NextScene1, NextScene2, NextScene3, NextScene4;
	int Akademik1, Sosial1, Ekonomi1, Cinta1;
	int Akademik2, Sosial2, Ekonomi2, Cinta2;
	int Akademik3, Sosial3, Ekonomi3, Cinta3;
	int Akademik4, Sosial4, Ekonomi4, Cinta4;

	public override void _Ready()
	{
		vBoxContainer = GetNode<VBoxContainer>("VBoxContainer");
		b1 = GetNode<Button>("VBoxContainer/Button");
		b2 = GetNode<Button>("VBoxContainer/Button2");
		b3 = GetNode<Button>("VBoxContainer/Button3");
		b4 = GetNode<Button>("VBoxContainer/Button4");
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void SetValues1(string path, int akademik, int sosial, int ekonomi, int cinta)
	{
		NextScene1 = path;
		Akademik1 = akademik;
		Sosial1 = sosial;
		Ekonomi1 = ekonomi;
		Cinta1 = cinta;
	}

	public void SetValues2(string path, int akademik, int sosial, int ekonomi, int cinta)
	{
		NextScene2 = path;
		Akademik2 = akademik;
		Sosial2 = sosial;
		Ekonomi2 = ekonomi;
		Cinta2 = cinta;
	}

	public void SetValues3(string path, int akademik, int sosial, int ekonomi, int cinta)
	{
		NextScene3 = path;
		Akademik3 = akademik;
		Sosial3 = sosial;
		Ekonomi3 = ekonomi;
		Cinta3 = cinta;
	}

	public void SetValues4(string path, int akademik, int sosial, int ekonomi, int cinta)
	{
		NextScene4 = path;
		Akademik4 = akademik;
		Sosial4 = sosial;
		Ekonomi4 = ekonomi;
		Cinta4 = cinta;
	}

	void OnButtonPressed()
	{
		MySingleton.AddValues(Akademik1, Sosial1, Ekonomi1, Cinta1);
		GetTree().ChangeSceneToFile(NextScene1);
	}

	void OnButtonPressed1()
	{
		MySingleton.AddValues(Akademik2, Sosial2, Ekonomi2, Cinta2);
		GetTree().ChangeSceneToFile(NextScene2);
	}

	void OnButtonPressed2()
	{
		MySingleton.AddValues(Akademik3, Sosial3, Ekonomi3, Cinta3);
		GetTree().ChangeSceneToFile(NextScene3);
	}

	void OnButtonPressed3()
	{
		MySingleton.AddValues(Akademik4, Sosial4, Ekonomi4, Cinta4);
		GetTree().ChangeSceneToFile(NextScene4);
	}

	public void SetButtonText (string b1Text, string b2Text, string b3Text, string b4Text)
	{
		b1.Text = b1Text;
		b2.Text = b2Text;
		b3.Text = b3Text;
		b4.Text = b4Text;

		if (b3Text.Length == 0 && b4Text.Length == 0) HideTwoLastBoxes();
		if (b4Text.Length == 0) HideLastBox();
	}

	public void ShowContainer()
	{
		Visible = true;
	}

	public void HideContainer()
	{
		Visible = false;
	}

	public void ShowBoxes()
	{
		b1.Visible = true;
		b2.Visible = true;
		b3.Visible = true;
		b4.Visible = true;
		animationPlayer.Play("Open");
	}

	public void HideBoxes()
	{
		b1.Visible = false;
		b2.Visible = false;
		b3.Visible = false;
		b4.Visible = false;
	}

	public void HideTwoLastBoxes()
	{
		b3.Visible = false;
		b4.Visible = false;
	}

	public void HideLastBox()
	{
		b4.Visible = false;
	}
}
