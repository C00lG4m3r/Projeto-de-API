using Godot;
using System;

public partial class big_powerup : power_up
{
	public override void PowerUpAction()
	{
		if (player_node.health < 2)
		{
		player_node.current_powerup = main_character.Player_PowerUps.big_powerup;
		player_node.health = 2;
		}
	}
}
