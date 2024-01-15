using Godot;
using System;

public partial class babe : CharacterBody2D
{
	public main_character player_node;
	public string message = "There's A Smoking Hot Babe At The Top!";
	public double typing_speed = 0.1;
	public int current_char = 0;
	public string display = "";
	public override void _Ready()
	{
		player_node = this.GetNode<main_character>("../CharacterBody2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		if (Position.DistanceTo(player_node.Position) < 500)
		{
			start_dialogue();
		}
		var overlapping_areas = GetNode<Area2D>("Area2D").GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
			var player = area.GetParent() as main_character;
			if (player != null) 
			{
				if (Input.IsActionJustPressed("Interact"))
				{
				}
			}
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
