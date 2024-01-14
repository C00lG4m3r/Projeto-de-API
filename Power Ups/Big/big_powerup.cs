using Godot;
using System;

public partial class big_powerup : power_up
{
	// Called when the node enters the scene tree for the first time.

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void PowerUpAction()
	{
		player_node.current_powerup = main_character.Player_PowerUps.big_powerup;
		if (this.player_node.health < 2)
		{
		player_node.health = 2;
		}
	}
}
