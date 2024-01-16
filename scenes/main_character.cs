using Godot;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class main_character : CharacterBody2D
{
	public enum Player_PowerUps
	{
		big_powerup,
		ninja,
		flash,
		time_warp,
		none
	}
	public Player_PowerUps current_powerup = Player_PowerUps.none;
	public PackedScene ninja_star_scene = GD.Load<PackedScene>("res://Projectiles/ninja_star.tscn");
	public float Speed = 400.0f;
	public Vector2 knockbackvelocity;
	public float JumpVelocity = -900.0f;
	public bool IsSwimming;
	public bool IsHighGravity;
	public bool IsLowGravity;
	public bool IsSuperLowGravity;
	public bool IsWinning;
	public AnimatedSprite2D Sprite2D;
	public int health = 1;
	public int bubblehealth;
	public bool time_warp;
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
			current_powerup = main_character.Player_PowerUps.big_powerup;
			time_warp=false;
		} else if (health == 1)
		{
			current_powerup = main_character.Player_PowerUps.none;
		} 

		if (health >= 2)
		{
			Speed = 420f;
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
			} else if (IsSuperLowGravity)
			{
				velocity.Y += gravity * (float)delta * (float)0.28571428571;
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
			if (IsWinning)
			{}else 
			{
				velocity.Y = JumpVelocity;
			}
		}


		// Directions and speed.
		Vector2 direction = Input.GetVector("Left", "Right", "ui_up", "ui_down");
		if(IsWinning)
		{} else
		{
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
				velocity.X = Mathf.MoveToward(Velocity.X, 0, 400);
			}	
		}
		velocity += knockbackvelocity;

		Velocity = velocity;
		MoveAndSlide();
		knockbackvelocity = Vector2.Zero;


		//Flip the sprite based on the direction.
		if (direction.X != 0) 
		{
			bool isLeft = velocity.X < 0;
			Sprite2D.FlipH = isLeft;
		}

		//Time Warp
		if (time_warp)
		{
			Engine.TimeScale = 0.7;
		} else 
		{
			Engine.TimeScale = 1;
		}


		//Power Ups
		switch (current_powerup)
		{
			case main_character.Player_PowerUps.ninja:
			if (Input.IsActionJustPressed("Power"))
			{if (IsWinning)
			{}else
			{
				mouse_pos = GetGlobalMousePosition();
				ninja_star star = ninja_star_scene.Instantiate<ninja_star>();
				AddSibling(star);
				star.Position = this.Position + this.Position.DirectionTo(mouse_pos) * 40;
				star.direction = this.Position.DirectionTo(mouse_pos);
				star.bullet_speed = 10;		
			} 
			}
			time_warp=false;
			break;
			case main_character.Player_PowerUps.flash:
			Speed = 470f;
			time_warp=false;
			break;
			case main_character.Player_PowerUps.time_warp:
			time_warp=true;
			break;
		}
	}
}
