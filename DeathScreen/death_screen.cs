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
		GetNode<Godot.Button>("CanvasLayer/Restart").Visible = true;
		GetNode<Godot.Button>("CanvasLayer/Main Menu").Visible = true;
		GetNode<Godot.Button>("CanvasLayer/Quit").Visible = true;
		GetNode<Godot.LineEdit>("CanvasLayer/YOUDIED").Visible = true;
		GetNode<Godot.TileMap>("CanvasLayer/TileMap").Visible = true;
		GetNode<Godot.Sprite2D>("CanvasLayer/Froggie 1").Visible = true;
		GetNode<Godot.Sprite2D>("CanvasLayer/Froggie 2").Visible = true;
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
