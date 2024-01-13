using Godot;
using System;

public partial class Spikes : Area2D
{
	public main_character Global_Player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global_Player = GetNode<main_character> ("../CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var overlapping_areas = this.GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
		var player = area.GetParent() as main_character;
		if (player != null) 
		{
			GD.Print("coco");
			player.health -= 1;
		}
		}
	}
}
