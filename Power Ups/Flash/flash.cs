using Godot;
using System;

public partial class flash : power_up
{
	public override void PowerUpAction()
	{
		this.player_node.current_powerup = main_character.Player_PowerUps.flash;
		this.player_node.health = 3;
	}
}
