using Godot;
using GodotPlugins.Game;
using System;

public partial class hud : Node2D
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
	switch (player_node.current_powerup) 
		{
			case main_character.Player_PowerUps.big_powerup:
				GetNode<Godot.Label>("CanvasLayer/Current PowerUp").Text = "Current Power Up: Big";
			break;
			case main_character.Player_PowerUps.ninja:
				GetNode<Godot.Label>("CanvasLayer/Current PowerUp").Text = "Current Power Up: Ninja";
			break;
			case main_character.Player_PowerUps.flash:
				GetNode<Godot.Label>("CanvasLayer/Current PowerUp").Text = "Current Power Up: Flash";
			break;
			case main_character.Player_PowerUps.time_warp:
				GetNode<Godot.Label>("CanvasLayer/Current PowerUp").Text = "Current Power Up: Time Warp";
			break;
			case main_character.Player_PowerUps.none:
				GetNode<Godot.Label>("CanvasLayer/Current PowerUp").Text = "Current Power Up: None";
			break;
		}
		if (Input.IsActionJustPressed("Pause"))
		{
			GetTree().Paused = !GetTree().Paused;
			GetNode<Godot.Button>("CanvasLayer/Pause").Visible = !GetNode<Godot.Button>("CanvasLayer/Pause").Visible;
			GetNode<Godot.Button>("CanvasLayer/Resume").Visible = !GetNode<Godot.Button>("CanvasLayer/Resume").Visible;
			GetNode<Godot.Button>("CanvasLayer/Main Menu").Visible = !GetNode<Godot.Button>("CanvasLayer/Main Menu").Visible;
			GetNode<Godot.Button>("CanvasLayer/Exit Game").Visible = !GetNode<Godot.Button>("CanvasLayer/Exit Game").Visible;
			GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible = !GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible;
		}
	}
		public void OnPausePressed() 
	{
	GetTree().Paused = !GetTree().Paused;
	GetNode<Godot.Button>("CanvasLayer/Pause").Visible = !GetNode<Godot.Button>("CanvasLayer/Pause").Visible;
	GetNode<Godot.Button>("CanvasLayer/Resume").Visible = !GetNode<Godot.Button>("CanvasLayer/Resume").Visible;
	GetNode<Godot.Button>("CanvasLayer/Main Menu").Visible = !GetNode<Godot.Button>("CanvasLayer/Main Menu").Visible;
	GetNode<Godot.Button>("CanvasLayer/Exit Game").Visible = !GetNode<Godot.Button>("CanvasLayer/Exit Game").Visible;
	GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible = !GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible;
	}
	private void OnResumePressed()
	{
	GetTree().Paused = false;
	GetNode<Godot.Button>("CanvasLayer/Pause").Visible = true;
	GetNode<Godot.Button>("CanvasLayer/Resume").Visible = false;
	GetNode<Godot.Button>("CanvasLayer/Main Menu").Visible = false;
	GetNode<Godot.Button>("CanvasLayer/Exit Game").Visible = false;
	GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible = false;
	}
	private void OnMainMenuPressed()
	{
	GetTree().ChangeSceneToFile("res://MainMenu/MainMenu.tscn");
	GetTree().Paused = !GetTree().Paused;
	}
	private void OnExitGamePressed()
	{
		GetTree().Quit();
	}
}
