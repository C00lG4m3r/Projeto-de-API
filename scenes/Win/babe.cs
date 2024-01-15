using Godot;
using System;

public partial class babe : CharacterBody2D
{
	public float Speed = 3f;
	public main_character player_node;
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
		if (Position.DistanceTo(player_node.Position) < 800)
		{
			start_dialogue();
		}
		if (player_node.Position.Y < -11345 && player_node.Position.X > 1170)
		{
			
		}
		MoveAndSlide();
	}
	public void start_dialogue()
	{
		GetNode<Timer>("./next_char").Start();
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
