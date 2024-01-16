using Godot;
using System;
using System.Linq;

public partial class babe : CharacterBody2D
{
	public float Speed = 100f;
	public main_character player_node;
	public Vector2 zoom_maximum = new Vector2(1.8f,1.8f);
	public Vector2 zoom_speed = new Vector2(.002f,.002f);
	public string message = "You Finally Found Me!!!";
	public double typing_speed = 0.1;
	public int current_char = 0;
	public string display = "";
	public bool IsAudioPlayed = false;
	public bool YouWon;
	public double elapsed_time;
	public double smoke_time;
	public bool prince;
	public override void _Ready()
	{
		player_node = GetNode<main_character>("../CharacterBody2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		if (Position.DistanceTo(player_node.Position) !> 800)
		{
			start_dialogue();
		}
		if (player_node.Position.Y < -11345 && player_node.Position.X > 1170)
		{
			player_node.IsWinning = true;
			player_node.Velocity = Vector2.Zero;
			if (GetNode<Camera2D>("../CharacterBody2D/Camera2D").Zoom < zoom_maximum)
			{
				GetNode<Camera2D>("../CharacterBody2D/Camera2D").Zoom += zoom_speed;
			}
			var overlapping_areas = GetNode<Area2D>("Kiss Area").GetOverlappingAreas();
			if (overlapping_areas.ToArray<Area2D>().Length == 1)
			{
				var direction = Position.DirectionTo(player_node.Position);
				velocity.X = direction.X * Speed;
			} else
			{
				elapsed_time += delta;
				velocity = Vector2.Zero;
				if (!IsAudioPlayed)
				{
					GetNode<AudioStreamPlayer2D>("./Kiss").Play();
					IsAudioPlayed = true;
				}
				player_node.GetNode<AnimatedSprite2D>("./Sprite2D").Visible = false;
				player_node.GetNode<AnimatedSprite2D>("./Smoke").Visible = true;
				player_node.GetNode<AnimatedSprite2D>("./Smoke").Play();
				smoke_time += delta;
				if (smoke_time > 1.48)
				{
					prince = true;
				}
				if (prince)
				{
				player_node.GetNode<AnimatedSprite2D>("./Smoke").Visible = false;
				player_node.GetNode<AnimatedSprite2D>("./Prince").Visible = true;
				}
			}
		}
		Velocity = velocity;
		MoveAndSlide();
		if (elapsed_time > 5)
		{
			YouWon = true;
			elapsed_time = 0;
		}
	}
	public void start_dialogue()
	{
		GetNode<Timer>("./Label/next_char").Start();
	}
		public void OnNextCharTimeout()
	{
		if (current_char < message.Length)
		{
			var next_char = message [current_char];
			display += next_char;
			GetNode<Label>("./Label").Text = display;
			current_char += 1;
		}
	}
}
