using Godot;
using System;
//
//   o 0
//   OOo
//   0o
//   ___
//   | |
//  /-------\
// /         \
// -----------
// |  | | [] |
// |  | |    |
// -----------  
// Ass: Lib (17/01/2024)
//
public partial class Cave : Area2D
{
	public main_character Global_Player;
	public AudioStreamPlayer cave;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global_Player = GetNode<main_character> ("../CharacterBody2D");
		cave = GetNode<AudioStreamPlayer>("../Cave2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Global_Player.IsCave = false;
		var overlapping_areas = this.GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
		var player = area.GetParent() as main_character;
		if (player != null) 
		{
			Global_Player.IsCave = true;
		}
		}
		if (Global_Player.IsCave)
		{
			if (!cave.Playing)
			{
				cave.Play();
			}
		} else 
		{
			cave.Stop();
		}
	}
}
