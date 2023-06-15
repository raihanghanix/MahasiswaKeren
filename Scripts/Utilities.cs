using Godot;
using System;

public partial class Utilites : Node
{
    public static Node InstantiateScene(PackedScene scene, string path)
	{
		Node instance;
		scene = GD.Load<PackedScene>(path);
		instance = scene.Instantiate();
		return instance;
	}
}
