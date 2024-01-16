using Godot;
using System;

public partial class water_enemy : CharacterBody2D
{
	public main_character player_node;
	public AnimatedSprite2D Sprite2D;
	public float Speed = 300.0f;
	public double elapsed_time;
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		this.player_node = GetNode<main_character>("../CharacterBody2D");
		Sprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		GD.Print(Sprite2D);	
	}

	public override void _PhysicsProcess(double delta)
	{
		elapsed_time += delta;
		//Player Tracking
		Vector2 velocity = Velocity;
		if(this.Position.DistanceTo(player_node.Position) < 750)
		{
			var direction = this.Position.DirectionTo(player_node.Position);
			velocity = direction * Speed;
			if (direction.X != 0) 
			{
				bool isLeft = velocity.X < 0;
				Sprite2D.FlipH = isLeft;
			}
		}
		var overlapping_areas = GetNode<Area2D>("./Area2D").GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
			var player = area.GetParent() as main_character;
			if (player != null && elapsed_time > 1) 
			{
				player.health -= 1;
				elapsed_time = 0;
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}
	public void OnAreaEntered(Area2D area)
	{
		if (area is ninja_star)
		{
			QueueFree();
		}
	}
}
