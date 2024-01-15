using Godot;
using System;

public partial class win : Node2D
{
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
			GetNode<Timer>("./Timer").Start();
		}
	}
	private void OnTimerTimeout()
	{
	GetTree().Quit();
	}
}
