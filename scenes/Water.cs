using Godot;
using System;

public partial class Water : Area2D
{
	public main_character Global_Player;
	public AudioStreamPlayer agua;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global_Player = GetNode<main_character> ("../CharacterBody2D");
		agua = GetNode<AudioStreamPlayer>("../Aquatic");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Global_Player.IsSwimming = false;
		var overlapping_areas = this.GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
		var player = area.GetParent() as main_character;
		if (player != null) 
		{
			Global_Player.IsSwimming = true;
		}
		}
		if (Global_Player.IsSwimming)
		{
			if (!agua.Playing)
			{
				agua.Play();
			}
		} else 
		{
			agua.Stop();
		}
	}
}