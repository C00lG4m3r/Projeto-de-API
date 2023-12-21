using Godot;
using System;

public partial class power_up : Area2D
{
	public string name = "test";
	public main_character player_node;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.player_node = this.GetNode<main_character>("../CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
