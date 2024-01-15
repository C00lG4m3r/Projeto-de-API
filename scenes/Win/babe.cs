using Godot;
using System;

public partial class babe : CharacterBody2D
{
	public float Speed = 3f;
	public main_character player_node;
	public Vector2 zoom_maximum = new Vector2(1.8f,1.8f);
	public Vector2 zoom_speed = new Vector2(.001f,.001f);
	public string message = "You Finally Found Me!!!";
	public double typing_speed = 0.1;
	public int current_char = 0;
	public string display = "";
	public override void _Ready()
	{
		player_node = this.GetNode<main_character>("../CharacterBody2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		if (Position.DistanceTo(player_node.Position) < 800)
		{
			start_dialogue();
		}
		if (player_node.Position.Y < -11345 && player_node.Position.X > 1170)
		{
			player_node.IsWinning = true;
			player_node.Velocity = Vector2.Zero;
			if (GetNode<Camera2D>("../CharacterBody2D/Camera2D").Zoom<zoom_maximum)
			{
				GetNode<Camera2D>("../CharacterBody2D/Camera2D").Zoom += zoom_speed;
			}
			var overlapping_areas = GetNode<Area2D>("./Area2D").GetOverlappingAreas();
			foreach (Area2D area in overlapping_areas)
			{
				var player = area.GetParent() as main_character;
				if (player == null) 
				{
					var direction = this.Position.DirectionTo(player_node.Position);
					velocity = direction * Speed;
				}else if (player != null)
				{
					
				}
			}
		}
		Velocity = velocity;
		MoveAndSlide();
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
