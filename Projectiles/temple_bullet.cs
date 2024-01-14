using Godot;
using System;

public partial class temple_bullet : Area2D
{
	public main_character player_node;
	public Vector2 direction;
	public int bullet_speed;
	public double elapsed_time = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player_node = GetNode<main_character>("../CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		elapsed_time += delta;
		this.Position += this.direction * bullet_speed;
			var overlapping_areas = this.GetOverlappingAreas();
			foreach (Area2D area in overlapping_areas)
		{
		var player = area.GetParent() as main_character;
			if (player != null && elapsed_time > 1) 
			{
				player.health -= 1;
				elapsed_time = 0;
			}
		}

			if (this.Position.X < -1800 || this.Position.X > 4400)
		{
			QueueFree();
		}
	}
}