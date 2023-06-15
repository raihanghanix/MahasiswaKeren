using Godot;
using System;

public partial class Scene4Special : Control
{
	int count = 0;
	int selection = 0;

	BG bg;
	Character character;
	Dialog dialog;
	Options options;
	Paramater paramater;

	public override void _Ready()
	{
		MySingleton.hasPrologScene = true;

		bg = (BG)GD.Load<PackedScene>("res://Scenes/bg.tscn").Instantiate();
		character = (Character)GD.Load<PackedScene>("res://Scenes/character.tscn").Instantiate();
		dialog = (Dialog)GD.Load<PackedScene>("res://Scenes/dialog.tscn").Instantiate();
		options = (Options)GD.Load<PackedScene>("res://Scenes/options.tscn").Instantiate();
		paramater = (Paramater)GD.Load<PackedScene>("res://Scenes/paramater.tscn").Instantiate();

		AddChild(bg);
		AddChild(character);
		AddChild(dialog);
		AddChild(options);
		AddChild(paramater);

		bg.SetBackground($"{MySingleton.backgroundPath}/Toko 6MT.png");
		dialog.SetDialogText($"Narator", $"Setelah berkendara sebentar kamu menemukan toko yang bernama \"Toko Manusia Taat\" dan memutuskan untuk mampir.");
		options.HideBoxes();

		count = 0;	
	}

	void OnButtonPressed()
	{
		count++;
		if (count == 1)
		{
			dialog.SetDialogText($"Narator", $"Setelah kamu turun dari motor Supra legend mu, tiba-tiba terdengar suara teriakan di dekatmu.");
		}
		if (count == 2)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");	
			dialog.SetDialogText($"???", $"Kyaaaaaaaaaa!");
		}
		if (count == 3)
		{
			character.RemoveCharacter();	
			dialog.SetDialogText($"Narator", $"Kamu melihat ke arah teriakan tersebut dan dengan sigap mengetahui itu merupakan sebuah tindakan pencopetan.");
		}
		if (count == 4)
		{
			dialog.SetDialogText($"Narator", $"Dengan sigap kamu menyandung pencopet yang lari kearahmu dan memberi kuncian maut dari gerakan silat yang kamu pelajari.");
		}
		if (count == 5)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Kembalikan dompet nya!");
		}
		if (count == 6)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Pencopet.png");
			dialog.SetDialogText($"Pencopet", $"Arrrrrgggg!");
		}
		if (count == 7)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Pencopet itu melepas tas yang Ia copet lalu kamu mengambil tas tersebut dan dengan bantuan warga sekitar pencopet tersebut ditangkap dan dibawa ke pihak berwajib.");
		}
		if (count == 8)
		{
			dialog.SetDialogText($"Narator", $"Setelah tertangkap nya pencopet tersebut kamu mengembalikan tas yang dicopet ke pemiliknya.");
		}
		if (count == 9)
		{
			dialog.SetDialogText($"{MySingleton.playerName}", $"Gak apa-apa kan kak?");
		}
		if (count == 10)
		{
			character.SetCharacter($"{MySingleton.characterPath}/Fitri.png");
			dialog.SetDialogText($"???", $"Ah, iya makasih ya udah ngebantuin aku. Terima kasih banget, maaf aku lagi buru-buru. Ini kartu nama aku makasih ya!");
		}
		if (count == 11)
		{
			character.RemoveCharacter();
			dialog.SetDialogText($"Narator", $"Wajah putih mulus nan seperti bidadari walau hanya sekilah hatimu berdegub dikarenakan kecantikan dari wanita tersebut.");
		}
		if (count == 12)
		{
			dialog.SetDialogText($"Narator", $"Wanita tersebut pergi dari tempat itu dan meninggalkanmu sebuah kartu nama yang berisikan nama dan kontaknya.");
		}
		if (count == 13)
		{
			dialog.SetDialogText($"Narator", $"Kamu mengumpukan kembali kesadaranmu setelah terhipnotis kecantikan wanita tersebut dan kembali ke tujuan awalmu ke toko untuk membeli minuman.");
		}
		if (count == 14)
		{
			GetTree().ChangeSceneToFile($"{MySingleton.scenePath}/scene_5.tscn");
		}
	}
}
