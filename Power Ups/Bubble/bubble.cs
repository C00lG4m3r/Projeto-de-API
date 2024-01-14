using Godot;
using System;

public partial class bubble : power_up
{
	public override void PowerUpAction()
	{
		player_node.current_powerup = main_character.Player_PowerUps.bubble;
		player_node.health =+ 2;
	}
}
