using Godot;
using System;

public partial class Sky : Area2D
{
	public main_character Global_Player;
	public AudioStreamPlayer sky;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global_Player = GetNode<main_character> ("../CharacterBody2D");
		sky = GetNode<AudioStreamPlayer>("../Sky2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Global_Player.IsLowGravity = false;
		var overlapping_areas = this.GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
		var player = area.GetParent() as main_character;
		if (player != null) 
		{
			Global_Player.IsLowGravity = true;
		}
		}
		if (Global_Player.IsLowGravity)
		{
			if (!sky.Playing)
			{
				sky.Play();
			}
		} else 
		{
			sky.Stop();
		}
	}
}
