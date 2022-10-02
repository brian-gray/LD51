using Godot;
using System;

public class Solar : Area2D
{

	[Signal]
	public delegate void FuelUp();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private void _on_Solar_area_entered(object area)
	{
		//f (area == "Ship"))
		//{
			QueueFree();
			Hide();
			EmitSignal(nameof(FuelUp));	
		//}
	}
}
