using Godot;
using System;

public abstract partial class power_up : Area2D
{
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
	private void OnBodyEntered(Node2D body)
	{
		this.PowerUpAction();
		this.QueueFree();
	}

	public abstract void PowerUpAction();
}	
