using Godot;
using System;

public class Snocket : Node2D
{
	[Export]
	public float velocity { get; set; } = 10;
	public Vector2 direction = new Vector2(0,-10);	// TODO update spawn to center screen and switch to (0.-10)
	Sprite shipSprite;
	public bool testing;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// initial velocity set to 10, update to speed or slow ship
		//velocity = 10;
		shipSprite = GetNode<Area2D>("Ship").GetNode<Sprite>("Sprite");
		shipSprite.Rotation = 0;
		testing = false;		// enable this bit to test velocity changes
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{	
		// UP: assign direction and rotation
		if (Input.IsActionPressed("ui_up"))
		{
			direction.x = 0;
			direction.y = -velocity;
			shipSprite.Rotation = 0;
			if (testing == true) velocity++;
		}
		// DOWN: assign direction and rotation
		if (Input.IsActionPressed("ui_down"))
		{
			direction.x = 0;
			direction.y = velocity;
			shipSprite.Rotation = Mathf.Pi;
			if (testing == true) velocity++;
		}
		// LEFT: assign direction and rotation
		if (Input.IsActionPressed("ui_left"))
		{
			direction.x = -velocity;
			direction.y = 0;
			shipSprite.Rotation = Mathf.Pi / -2;
			if (testing == true) velocity++;
		}
		// RIGHT: assign direction and rotation
		if (Input.IsActionPressed("ui_right"))
		{
			direction.x = velocity;
			direction.y = 0;
			shipSprite.Rotation = Mathf.Pi / 2;
			if (testing == true) velocity++;
		}
			
		MoveSnocket();
	}
	
	public void MoveSnocket()
	{
		var shipPosition = GetNode<Area2D>("Ship").Position;
		GetNode<Area2D>("Ship").Position += direction/2;
	}
}
