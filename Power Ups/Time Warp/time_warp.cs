using Godot;
using System;

public partial class time_warp : power_up
{
	public override void PowerUpAction()
	{
		player_node.current_powerup = main_character.Player_PowerUps.time_warp;
		player_node.health = 3;
	}
}
