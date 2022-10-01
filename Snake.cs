using Godot;
using System;

public class Snake : Node2D
{
	public float velocity;
	public Vector2 direction = new Vector2(10,0);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		velocity = 10;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (Input.IsActionPressed("ui_up"))
		{
			direction.x = 0;
			direction.y = -velocity;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			direction.x = 0;
			direction.y = velocity;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			direction.x = -velocity;
			direction.y = 0;
		}
		if (Input.IsActionPressed("ui_right"))
		{
			direction.x = velocity;
			direction.y = 0;
		}
			
		MoveSnake();
	}
	
	public void MoveSnake()
	{
		var shipPosition = GetNode<Area2D>("Ship").Position;
		GetNode<Area2D>("Ship").Position += direction/2;
	}
}
