using Godot;
using System;

public partial class temple_enemy : CharacterBody2D
{
	public main_character player_node;
	public Vector2 player_pos;
	public PackedScene temple_bullet_scene = GD.Load<PackedScene>("res://Projectiles/temple_bullet.tscn");

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		this.player_node = GetNode<main_character>("../CharacterBody2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
				if(this.Position.DistanceTo(player_node.Position) < 750)
		{
			player_pos = GetNode<main_character>("..//CharacterBody2D").Position;
			var direction = this.Position.DirectionTo(player_node.Position);
			temple_bullet shot = temple_bullet_scene.Instantiate<temple_bullet>();
			AddSibling(shot);
			shot.Position = this.Position + this.Position.DirectionTo(player_pos) * 40;
			shot.direction = this.Position.DirectionTo(player_pos);
			shot.bullet_speed = 10;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}