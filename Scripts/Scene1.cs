using Godot;
using System;
using System.Collections.Generic;

public partial class Scene1 : Node2D
{
	int num = 0;
	string playerName;
	Control optionsControl;
	List<string> naratorDialog = new List<string>();
	List<string> playerDialog = new List<string>();

	private void SetPlayerName()
	{
		if (NameSelect.PlayerName != null)
		{
			playerName = NameSelect.PlayerName;
		} 
		else
		{
			playerName = "John Doe";
		}
	}

	private void SetCharaNameLabel()
	{
		if (NameSelect.PlayerName != null)
		{
			Dialog.charaNameLabel.Text = NameSelect.PlayerName;
		} 
		else
		{
			Dialog.charaNameLabel.Text = "John Doe";
		}
	}

	private void ShowCharaNameAndDialogBoxText(bool visibile, string dialog)
	{
		Dialog.charaName.Visible = Visible;
		Dialog.dialogBoxLabel.Text = dialog;
	}

    public override void _Ready()
    {
		optionsControl = GetNode<Control>("OptionsControl");
		optionsControl.Visible = false;

		SetPlayerName();
		SetCharaNameLabel();

        var dialog = new Scene1DialogManager
		{
			Narators = new List<Scene1Narator>
			{
				new Scene1Narator
				{
					Dialog = $"Nama kamu adalah {playerName}, kamu adalah mahasiswa sistem informasi semester 5, dan saat ini kamu sedang bersiap siap kembali ke kosan setelah liburan yang tenang dan menyenangkan."
				}
			},
			Players = new List<Scene1Player>
			{
				new Scene1Player
				{
					Dialog = "Apa yang sebaiknya ku lakukan sekarang?"
				}
			}
		};
		
		foreach (var text in dialog.Narators)
        {
            naratorDialog.Add(text.Dialog);
        }
		foreach (var text in dialog.Players)
        {
        	playerDialog.Add(text.Dialog);
        }

		Dialog.charaName.Visible = false;
		Dialog.dialogBoxLabel.Text = naratorDialog[0];
    }

    private void OnButtonPressed()
	{
		num++;
		if (num == 1)
		{
			ShowCharaNameAndDialogBoxText(true, playerDialog[0]);
		}
		else if (num == 2)
		{
			optionsControl.Visible = true;
		}
	}
}

