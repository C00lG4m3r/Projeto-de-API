using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

public partial class InicialLabel : Label
{
	public main_character player_node;
	public string message = "There's A Smoking Hot Babe At The Top!";
	public double typing_speed = 0.1;
	public int current_char = 0;
	public string display = "";
	public override void _Ready()
	{
		player_node = this.GetNode<main_character>("../CharacterBody2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		if (Position.DistanceTo(player_node.Position) !> 350)
		{
			start_dialogue();
		}
	}
	public void start_dialogue()
	{
		GetNode<Timer>("./next_char").Start();
	}
	public void OnNextCharTimeout()
	{
		if (current_char < message.Length)
		{
			var next_char = message [current_char];
			display += next_char;
			Text = display;
			current_char += 1;
		}
	}
}
