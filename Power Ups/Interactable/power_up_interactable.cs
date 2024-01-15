using Godot;
using System;

public partial class power_up_interactable : Area2D
{
	public main_character player_node;
	public double elapsed_time;
	public bool WasPressed;
	public PackedScene ninja_powerup_scene = GD.Load<PackedScene>("res://Power Ups/Ninja/ninja.tscn");
	public PackedScene big_powerup_scene = GD.Load<PackedScene>("res://Power Ups/Big/big_powerup.tscn");
	public PackedScene flash_powerup_scene = GD.Load<PackedScene>("res://Power Ups/Flash/flash.tscn");
	public PackedScene time_warp_powerup_scene = GD.Load<PackedScene>("res://Power Ups/Time Warp/time_warp.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player_node = this.GetNode<main_character>("../CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (WasPressed)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Animation = "hit";
			elapsed_time += delta;
			if (elapsed_time > 1)
			{
				Random _R = new Random ();
				var pwr = Enum.GetValues (typeof (main_character.Player_PowerUps));
				var selected_powerup = (main_character.Player_PowerUps)pwr.GetValue (_R.Next(pwr.Length));
				switch (selected_powerup) 
				{
					case main_character.Player_PowerUps.big_powerup:
						var big_powerup_instance = big_powerup_scene.Instantiate<big_powerup>();
						big_powerup_instance.Position = this.Position + new Vector2(0, -80);
						AddSibling(big_powerup_instance);
					break;
					case main_character.Player_PowerUps.ninja:
						var ninja_powerup_instance = ninja_powerup_scene.Instantiate<ninja>();
						ninja_powerup_instance.Position = this.Position + new Vector2(0, -80);
						AddSibling(ninja_powerup_instance);
					break;
					case main_character.Player_PowerUps.flash:
						var flash_powerup_instance = flash_powerup_scene.Instantiate<flash>();
						flash_powerup_instance.Position = this.Position + new Vector2(0, -60);
						AddSibling(flash_powerup_instance);
					break;
					case main_character.Player_PowerUps.time_warp:
						var time_warp_powerup_instance = time_warp_powerup_scene.Instantiate<time_warp>();
						time_warp_powerup_instance.Position = this.Position + new Vector2(0, -60);
						AddSibling(time_warp_powerup_instance);
					break;
					case main_character.Player_PowerUps.none:
						var big_powerup_instance2 = big_powerup_scene.Instantiate<big_powerup>();
						big_powerup_instance2.Position = this.Position + new Vector2(0, -80);
						AddSibling(big_powerup_instance2);
					break;
					}
				QueueFree();
			}
		}
		var overlapping_areas = GetOverlappingAreas();
		foreach (Area2D area in overlapping_areas)
		{
			var player = area.GetParent() as main_character;
			if (player != null) 
			{
				if (Input.IsActionJustPressed("Interact"))
				{
					WasPressed = true;
				}
			}
		}
		if (Position.DistanceTo(player_node.Position) < 850)
		{
			GetNode<Label>("Press E").Visible = true;
		} else 
		{
			GetNode<Label>("Press E").Visible = false;
		}
	}
}
