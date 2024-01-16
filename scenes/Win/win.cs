using Godot;
using System;

public partial class win : Node2D
{
	public double elapsed_time;
	public babe win_node;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		win_node = GetNode<babe>("../Babe");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (win_node.YouWon) 
		{
			GetNode<Godot.LineEdit>("CanvasLayer/LineEdit").Visible = true;
			elapsed_time += delta;
			if (elapsed_time > 10)
			{
				GetTree().Quit();
			}
			GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible = true;
			GetNode<Godot.AnimatedSprite2D>("CanvasLayer/AnimatedSprite2D").Visible = true;
			GetNode<Godot.AnimatedSprite2D>("CanvasLayer/AnimatedSprite2D2").Visible = true;
		}
	}
}
