using Godot;
using System;

public partial class death_screen : Node2D
{
	public main_character Global_Player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global_Player = GetNode<main_character>("../CharacterBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Global_Player.health <= 0 || Global_Player.Position.Y >= 2726) 
		{
		GetNode<Godot.Button>("DeathScreen/Restart").Visible = true;
		GetNode<Godot.Button>("DeathScreen/MainMenu").Visible = true;
		GetNode<Godot.Button>("DeathScreen/Quit").Visible = true;
		GetNode<Godot.LineEdit>("DeathScreen/YOUDIED").Visible = true;
		GetNode<Godot.TileMap>("DeathScreen/TileMap").Visible = true;
		GetTree().Paused = true;
		}
	}
	private void OnRestartPressed()
	{
	GetTree().Paused = false;
	GetTree().ReloadCurrentScene();
	}


	private void OnMainMenuPressed()
	{
	GetTree().ChangeSceneToFile("res://MainMenu/MainMenu.tscn");
	GetTree().Paused = !GetTree().Paused;
	}


	private void OnQuitPressed()
	{
	GetTree().Quit();
	}
}
