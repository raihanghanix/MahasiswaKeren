using Godot;
using System;

public partial class Paramater : Control
{
    Label akademikLabel, sosialLabel, keuanganLabel, hatiLabel;
    AnimationPlayer anim;

    public override void _Ready()
	{
        akademikLabel = GetNode<Label>("Parameters/AkademikLabel");
        sosialLabel = GetNode<Label>("Parameters/SosialLabel");
        keuanganLabel = GetNode<Label>("Parameters/KeuanganLabel");
        hatiLabel = GetNode<Label>("Parameters/HatiLabel");

        anim = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _Process(double delta)
	{
        akademikLabel.Text = MySingleton.Akademik.ToString();
        sosialLabel.Text = MySingleton.Sosial.ToString();
        keuanganLabel.Text = MySingleton.Ekonomi.ToString();
        hatiLabel.Text = MySingleton.Cinta.ToString();
	}

    public void ChangeColor()
    {
        anim.Play("Green");
    }
}
