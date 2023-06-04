using Godot;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

public class DialogData
{
    public List<DialogEntry> dialog { get; set; }
    public List<OptionData> options { get; set; }
}

public class DialogEntry
{
    public string name { get; set; }
    public string text { get; set; }
}

public class OptionData
{
    public string text { get; set; }
    public StatsData stats { get; set; }
}

public class StatsData
{
    public int affection { get; set; }
    public int social { get; set; }
    public int academic { get; set; }
    public int economy { get; set; }
}

public partial class Scene1 : Control
{
	int count = 0;
	string json, modifiedJson, playerName;

	DialogData data;

	PackedScene parameterScene, dialogScene;
	Node parameterInstance, dialogInstance;
	Label name, text;
	Control optGroup;
	AnimationPlayer	parameterAnim;
	Timer timer;

	public override void _Ready()
	{
		optGroup = GetNode<Control>("OptGroup");
		timer = GetNode<Timer>("Timer");

		parameterInstance = InstantiateSceneAndAddChild(parameterScene, "res://Scenes/paramater.tscn");
		dialogInstance = InstantiateSceneAndAddChild(dialogScene, "res://Scenes/dialog.tscn");

		parameterAnim = parameterInstance.GetNode<AnimationPlayer>("AnimationPlayer");

		if (NameSelect.PlayerName != null)
		{
			playerName = NameSelect.PlayerName;
		}
		else
		{
			playerName = "John Doe";
		}

		name = dialogInstance.GetNode<Label>("CharaNameText");
		text = dialogInstance.GetNode<Label>("DialogBoxText");

		json = @"
        {
          ""dialog"": [
            {
              ""name"": ""Narator"",
              ""text"": ""Nama kamu adalah *playerName*, kamu adalah mahasiswa sistem informasi semester 5, dan saat ini kamu sedang bersiap siap kembali ke kosan setelah liburan yang tenang dan menyenangkan.""
            },
            {
              ""name"": ""*playerName*"",
              ""text"": ""Apa yang sebaiknya ku lakukan sekarang?""
            }
          ],
          ""options"": [
            {
              ""text"": ""Berbicara dengan orang tua"",
              ""stats"": { ""affection"": 0, ""social"": 0, ""academic"": 0, ""economy"": 0 }
            },
            {
              ""text"": ""Menelpon teman"",
              ""stats"": { ""affection"": 0, ""social"": 40, ""academic"": 0, ""economy"": 0 }
            },
            {
              ""text"": ""Lanjut ngoding"",
              ""stats"": { ""affection"": 0, ""social"": 0, ""academic"": 40, ""economy"": 0 }
            },
            {
              ""text"": ""Mengecek kembali barang dan persediaan"",
              ""stats"": { ""affection"": 0, ""social"": 0, ""academic"": 0, ""economy"": 40 }
            }
          ]
        }";

		modifiedJson = json.Replace("*playerName*", playerName);
		data = JsonSerializer.Deserialize<DialogData>(modifiedJson);

		optGroup.Visible = false;

		ChangeDialogNameAndText();
	}

	Node InstantiateSceneAndAddChild(PackedScene scene, string path)
	{
		Node instance;
		scene = GD.Load<PackedScene>(path);
		instance = scene.Instantiate();
		AddChild(instance);
		return instance;
	}

	void HideDialogNameBox()
	{
		var box = dialogInstance.GetNode<Panel>("CharaNameBox");
		name.Visible = false;
		box.Visible = false;
	}

	void ShowDialogNameBox()
	{
		var box = dialogInstance.GetNode<Panel>("CharaNameBox");
		name.Visible = true;
		box.Visible = true;
	}

	void ChangeDialogNameAndText()
	{
		if (data.dialog[count].name == "Narator")
		{
			HideDialogNameBox();
		}
		else
		{
			ShowDialogNameBox();
		}

		name.Text = data.dialog[count].name;
		text.Text = data.dialog[count].text;
	}

	void OnButtonPressed()
	{	
		count++;

		if (count == 1)
		{
			ChangeDialogNameAndText();
		}
		else if (count == 2)
		{
			optGroup.Visible = true;
		}	
	}

	void OnOpt1Pressed()
	{
		MySingleton.AddValues(0, 0, 0, 0);
		parameterAnim.Play("Green");
		timer.Start();
	}

	void OnOpt2Pressed()
	{
		MySingleton.AddValues(0, 15, 0, 0);
		parameterAnim.Play("Green");
		timer.Start();
	}

	void OnOpt3Pressed()
	{
		MySingleton.AddValues(0, 0, 15, 0);
		parameterAnim.Play("Green");
		timer.Start();
	}

	void OnOpt4Pressed()
	{
		MySingleton.AddValues(0, 0, 0, 15);
		parameterAnim.Play("Green");
		timer.Start();
	}

	void OnTimerTimeout()
	{
		GetTree().ReloadCurrentScene();
	}
}

