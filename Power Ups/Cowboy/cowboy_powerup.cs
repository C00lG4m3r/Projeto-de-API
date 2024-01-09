using Godot;
using System;

public partial class cowboy_powerup : power_up
{
	// Called when the node enters the scene tree for the first time.

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void PowerUpAction()
	{
		this.player_node.health = 3;
		
	}
}