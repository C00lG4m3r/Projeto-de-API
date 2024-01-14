using Godot;
using System;

public partial class ninja : power_up
{
	public override void PowerUpAction()
	{
		this.player_node.current_powerup = main_character.Player_PowerUps.ninja;
		this.player_node.health = 3;
	}
}
