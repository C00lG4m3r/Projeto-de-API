using Godot;
using System;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_button_pressed()
	{
		GetTree().Quit();
	}
	private void _on_button_2_pressed()
	{
		GetTree().ChangeSceneToFile("res://main.tscn");
	}
	private void _on_button_3_pressed()
	{
		GetNode<Godot.Button>("Button").Hide();
		GetNode<Godot.Button>("Button2").Hide();
		GetNode<Godot.Button>("Button3").Hide();
		GetNode<Godot. Label>("Label").Show();
		GetNode<Godot.Button>("Button4").Show();
	}
	private void _on_button_4_pressed()
	{
		GetNode<Godot.Button>("Button").Show();
		GetNode<Godot.Button>("Button2").Show();
		GetNode<Godot.Button>("Button3").Show();
		GetNode<Godot. Label>("Label").Hide();
		GetNode<Godot.Button>("Button4").Hide();
	}
}
