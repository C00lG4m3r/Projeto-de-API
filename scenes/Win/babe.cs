using Godot;
using System;

public partial class babe : CharacterBody2D
{
	public main_character player_node;
	public override void _Ready()
	{
		player_node = this.GetNode<main_character>("../CharacterBody2D");
	}
	public override void _PhysicsProcess(double delta)
	{
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
}
