using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class main_character : CharacterBody2D
{
	public enum Player_PowerUps
	{
		ninja,
		none
	}
	public Player_PowerUps current_powerup = Player_PowerUps.none;
	public PackedScene ninja_star_scene = GD.Load<PackedScene>("res://Projectiles/ninja_star.tscn");
	public const float Speed = 400.0f;
	public float JumpVelocity = -900.0f;
	public bool IsSwimming;
	public bool IsHighGravity;
	public bool IsLowGravity;
	private AnimatedSprite2D Sprite2D;
	public int health = 1;
	public Vector2 mouse_pos;

	public override void _Ready()
	{
		Sprite2D = GetNode<AnimatedSprite2D>("Sprite2D");
		GD.Print(Sprite2D);
	}

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{


		//Health stages, scale.
		if(health==2) 
		{
			this.Scale = new Vector2(1,1.4f);
		} else
		{
			this.Scale = new Vector2(1,1);
		}


		//Teleport the player to the start position and reset health.
		if (this.Position.Y >= 2726 || this.health == 0)
		{
			this.health = 1;
			this.Position = new Vector2(382, 705);
		}

		Vector2 velocity = Velocity;
		

		// Animations.
		if (Math.Abs(velocity.X) > 1)
		{
			Sprite2D.Animation = "running";
		}

		else
		{
			Sprite2D.Animation = "default";
		}
		

		// Gravity and jump animation.
		if (!IsOnFloor())
		{
		Sprite2D.Animation = "jumping";
			if (IsSwimming)
			{
				if (velocity.Y < 300) 
				{
				velocity.Y += gravity * (float)delta * (float)0.6;
				}
				JumpVelocity = -450.0f;
			} else if (IsHighGravity) 
			{
				velocity.Y += gravity * (float)delta * (float)1.35714285714;
				JumpVelocity = -900.0f;
			} else if (IsLowGravity)
			{
				velocity.Y += gravity * (float)delta * (float)0.57142857142;
				JumpVelocity = -900.0f;
			} else
			{
				velocity.Y += gravity * (float)delta;
				JumpVelocity = -900.0f;
			}
		} 
	

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && (IsOnFloor() || IsSwimming))
		{
			velocity.Y = JumpVelocity;
		}


		// Directions and speed.
		Vector2 direction = Input.GetVector("Left", "Right", "ui_up", "ui_down");
		direction = direction.Normalized();
		if (direction.X > 0)
		{
			velocity.X = Speed;
		}
		else if (direction.X < 0)
		{
			velocity.X = -Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 100);
		}

		Velocity = velocity;
		MoveAndSlide();


		//Flip the sprite based on the direction.
		if (direction.X != 0) 
		{
			bool isLeft = velocity.X < 0;
			Sprite2D.FlipH = isLeft;
		}


		//Power Ups
		switch (current_powerup)
		{
			case main_character.Player_PowerUps.ninja:
			if (Input.IsActionJustPressed("Power"))
			{
				mouse_pos = GetGlobalMousePosition();
				ninja_star star = ninja_star_scene.Instantiate<ninja_star>();
				AddSibling(star);
				star.Position = this.Position + this.Position.DirectionTo(mouse_pos) * 40;
				star.direction = this.Position.DirectionTo(mouse_pos);
				star.bullet_speed = 10;
			}
			break;
		}		
	}
}
