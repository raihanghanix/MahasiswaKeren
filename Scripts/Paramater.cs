using Godot;
using System;

public partial class Paramater : Control
{
    [Export] public PackedScene cwScene { get; set; }
	ConfirmationWindow cw;

    Label akademikLabel, sosialLabel, keuanganLabel, hatiLabel;
    AnimationPlayer anim;
    Button menu;

    public override void _Ready()
	{
        akademikLabel = GetNode<Label>("Parameters/AkademikLabel");
        sosialLabel = GetNode<Label>("Parameters/SosialLabel");
        keuanganLabel = GetNode<Label>("Parameters/KeuanganLabel");
        hatiLabel = GetNode<Label>("Parameters/HatiLabel");
        anim = GetNode<AnimationPlayer>("AnimationPlayer");

        menu = GetNode<Button>("Parameters/Menu");

        cw = cwScene.Instantiate<ConfirmationWindow>();
		AddChild(cw);
	}

	public override void _Process(double delta)
	{
        akademikLabel.Text = MySingleton.Akademik.ToString();
        sosialLabel.Text = MySingleton.Sosial.ToString();
        keuanganLabel.Text = MySingleton.Ekonomi.ToString();
        hatiLabel.Text = MySingleton.Cinta.ToString();
	}

    void OnMenuPressed()
    {
        MySingleton.selection = 5;
        cw.SetMessage("Apakah kamu ingin kembali ke halaman utama?");
        cw.Open();
    }
}
