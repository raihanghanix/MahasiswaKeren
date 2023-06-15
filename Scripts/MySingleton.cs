using Godot;
using System;

[Tool]
public partial class MySingleton : Node
{
	public static int Akademik = 25;
	public static int Sosial = 25;
	public static int Ekonomi = 25;
	public static int Cinta = 0;

	public static int selection { get; set; }

	public static string scenePath = "res://Scenes";
	public static string backgroundPath = "res://Assets/Backgrounds";
	public static string characterPath = "res://Assets/Characters";

	public static string playerName = "John Doe";
	
	public static bool hasPrologScene = false;
	public static bool hasBecomeCommitte = false;

	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{

	}

	public static void SetPlayerName(string name)
	{
		playerName = name;
	}

	public static void PrintValues()
	{
		GD.Print($"{Akademik}, {Sosial}, {Ekonomi}, {Cinta}");
	}

	public static void AddValues(int akademik, int sosial, int ekonomi, int cinta)
	{
		Akademik += akademik;
		Sosial += sosial;
		Ekonomi += ekonomi;
		Cinta += cinta;
	}

	public static void ResetValues()
	{
		Akademik = 25;
		Sosial = 25;
		Ekonomi = 25;
		Cinta = 0;
	}
}
