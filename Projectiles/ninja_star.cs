using Godot;
using System;


public partial class ninja_star : Area2D
{
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
		if (this.Position.X < -1800 || this.Position.X > 4400)
		{
			QueueFree();
		}
	}
}
