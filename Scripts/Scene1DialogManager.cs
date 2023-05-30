using Godot;
using System;
using System.Collections.Generic;

public partial class Scene1DialogManager
{
    public List<Scene1Narator> Narators {get; set;}
    public List<Scene1Player> Players {get; set;}
}
public class Scene1Narator
{
    public string Dialog { get; set; }
}
public class Scene1Player
{
    public string Dialog { get; set; }
}