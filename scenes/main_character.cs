using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class main_character : CharacterBody2D
{
	public const float Speed = 400.0f;
	public const float JumpVelocity = -900.0f;

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
		//Teleport the player to the start position.
		if (this.Position.Y >= 1110 || this.health == 0)
		{
			this.health = 1;
			this.Position = new Vector2(204, 800);
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
			velocity.Y += gravity * (float)delta;
		Sprite2D.Animation = "jumping";
		}
	
		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
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
