using Godot;
using System;

public partial class OptionButton : CanvasLayer
{
	string name = "John Doe";

	public override void _Ready()
	{
		Callable callable = Callable.From(() => this._on_button_pressed());
		for (int i = 0; i < 4; i++)
		{
			Button button = new Button();
			button.Text = "Button " + (i + 1);
			button.Connect("pressed", callable);	
			AddChild(button);
		}
	}

	void SayHello(string name)
	{
		GD.Print($"Hello {name}");
	}

	public override void _Process(double delta)
	{

	}

	void _on_button_pressed()
	{
		GD.Print("LOL");
	}
}
