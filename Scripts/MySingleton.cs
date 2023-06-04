using Godot;
using System;

[Tool]
public partial class MySingleton : Node
{
	[Export] public static int Cinta = 0;
	[Export] public static int Sosial = 25;
	[Export] public static int Akademik = 25;
	[Export] public static int Ekonomi = 25;

	public static void PrintValues()
	{
		GD.Print($"{Cinta}, {Sosial}, {Akademik}, {Ekonomi}");
	}

	public static void AddValues(int cinta, int sosial, int akademik, int ekonomi)
	{
		Cinta += cinta;
		Sosial += sosial;
		Akademik += akademik;
		Ekonomi += ekonomi;
	}
}
