using Godot;
using System;

public partial class PaddleR : CharacterBody2D{
	[Export]
	public int Speed = 5;

	public void GetInput(){


		bool UpPressed = Input.IsActionPressed("RightPaddleUp");
		bool DownPressed = Input.IsActionPressed("RightPaddleDown");

		if (UpPressed && DownPressed){}
		else if(UpPressed){
			Velocity = new Vector2(0, -(float)Speed);
		}
		else if(DownPressed){
			Velocity = new Vector2(0, (float)Speed);
		}
		else{
			Velocity = new Vector2();
		}
		
	}

    public override void _Process(double delta)
    {
		
		GetInput();
		MoveAndCollide(Velocity);

	}
}
