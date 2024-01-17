using Godot;
using System;

public partial class Space : Area2D
{
	public main_character Global_Player;
	public AudioStreamPlayer space;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global_Player = GetNode<main_character> ("../CharacterBody2D");
		space = GetNode<AudioStreamPlayer>("../Space2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Global_Player.IsSuperLowGravity = false;
		var overlapping_areas = this.GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
		var player = area.GetParent() as main_character;
		if (player != null) 
		{
			Global_Player.IsSuperLowGravity = true;
		}
		}
		if (Global_Player.IsSuperLowGravity && !Global_Player.IsWinning)
		{
			if (!space.Playing)
			{
				space.Play();
			}
		} else 
		{
			space.Stop();
		}
	}
}
