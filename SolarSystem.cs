using Godot;
using System;

public class SolarSystem : Node2D
{
	public Node2D player;
	public Sprite flare;
	public Timer timer;
	public int score;
	public float speed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		score = 0;
		GD.Randomize();
		flare = GetNode<Area2D>("Solar").GetNode<Sprite>("Sprite");
		timer = GetNode<Timer>("Timer");
		timer.Start();
		SpawnFlare();
	}

	//Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		// Display Timer
		var warpLabel = GetNode<Label>("Warp");
		warpLabel.Text = "Warp in: " + timer.TimeLeft.ToString();
		
		// Display Score
		var scoreLabel = GetNode<Label>("Score");
		scoreLabel.Text = "Score: " + score.ToString();
		
		// Display Speed
		player = GetNode<Node2D>("Snocket");
		speed = (float)player.Get("velocity");
		var speedLabel = GetNode<Label>("Speed");
		speedLabel.Text = "Speed: " + speed.ToString();
	}

	public void AddFlare()
	{
		// TODO determine which instance of 'flare' to use
		//var flareInstance = (Solar)SolarScene.Instance();
		flare.Position = new Vector2(250, 250);
		score++;
		//AddChild(flare);
	}
	
	public void SpawnFlare()
	{
		AddFlare();
	}
}
