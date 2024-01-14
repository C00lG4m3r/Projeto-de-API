using Godot;
using System;

public partial class desert_bullet : Area2D
{
	public main_character player_node;
	public Vector2 direction;
	public int bullet_speed;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Position += this.direction * bullet_speed;
		//player_node.Velocity.X -= 350;
		//player_node.Velocity = velocity;
	}
}
