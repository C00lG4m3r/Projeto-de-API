using Godot;
using System;

public partial class power_up_interactable : Area2D
{
	public main_character player_node;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player_node = this.GetNode<main_character>("../CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var overlapping_areas = GetNode<Area2D>("./Area2D").GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
			var player = area.GetParent() as main_character;
			if (player != null) 
			{
				if (Input.IsActionJustPressed("Interact"))
				{
					Random _R = new Random ();
					Player_PowerUps RandomEnumValue<Player_PowerUps> ()
					{
						var pwr = Enum.GetValues (typeof (Player_PowerUps));
						return (Player_PowerUps) pwr.GetValue (_R.Next(pwr.Length));
					}
				}
			}
		}
	}
}
