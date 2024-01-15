using Godot;
using System;

public partial class desert_enemy : CharacterBody2D
{
	public main_character player_node;
	public Vector2 player_pos;
	public double elapsed_time;
	public PackedScene desert_bullet_scene = GD.Load<PackedScene>("res://Projectiles/desert_bullet.tscn");

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		this.player_node = GetNode<main_character>("../CharacterBody2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		elapsed_time += delta;
		Vector2 velocity = Velocity;
		if (-2600 <= player_node.Position.Y && player_node.Position.Y <= -700 && elapsed_time > 8)
		{
			player_pos = GetNode<main_character>("..//CharacterBody2D").Position;
			var direction = this.Position.DirectionTo(player_node.Position);
			desert_bullet shot = desert_bullet_scene.Instantiate<desert_bullet>();
			AddSibling(shot);
			shot.Position = this.Position + this.Position.DirectionTo(player_pos) * 40;
			shot.direction = this.Position.DirectionTo(player_pos);
			shot.bullet_speed = 10;
			elapsed_time = 0;
		}
		if (this.Position.X < -1800 || this.Position.X > 4400)
		{
			QueueFree();
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
