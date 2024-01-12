using Godot;
using System;

public partial class temple_enemy : CharacterBody2D
{
	public main_character player_node;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
        this.player_node = GetNode<main_character>("../CharacterBody2D");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
				if(this.Position.DistanceTo(player_node.Position) < 750)
		{
			var direction = this.Position.DirectionTo(player_node.Position);
			velocity = direction;
		}


		Velocity = velocity;
		MoveAndSlide();
	}
}
