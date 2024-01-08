using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class main_character : CharacterBody2D
{
	public const float Speed = 400.0f;
	public const float JumpVelocity = -900.0f;
	public bool IsSwimming;

	public bool IsHighGravity;

	//public string = "";

	private AnimatedSprite2D Sprite2D;

	public int health = 1;
	

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
			} else if (IsHighGravity) 
			{
				velocity.Y += gravity * (float)delta * (float)1.42857142857;
			} else
			{
				velocity.Y += gravity * (float)delta;
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
	}

}
