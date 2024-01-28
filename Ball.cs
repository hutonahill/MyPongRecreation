using Godot;
using System;
using System.Reflection;

public partial class Ball : RigidBody2D
{

	private int ballSpeed = 400;

	public int startX = 579;
	public int startY = 310;

	public override void _Ready(){
        Area2D goalL = GetNode<Area2D>("../GoalL");
        Area2D goalR = GetNode<Area2D>("../GoalR");

        //Callable goalLCallable = new Callable(goalL, nameof(OnGoalLAreaEntered));

        // goalL.BodyEntered += OnGoalLBodyEntered;
        // goalR.BodyEntered += OnGoalRBodyEntered;


		
		ResetBall();

        GD.Print("Game Started");
    }

    public void ResetBall()
    {
        Position = new Vector2(startX, startY);

        // generate a random direction
        Tuple<int, int> direction = GetRandomDirection();

        // convert the direction to a vector
        Vector2 ballVelocity = new Vector2(direction.Item1 * ballSpeed, direction.Item2 * ballSpeed);

        // apply the direction to the ball
        LinearVelocity = ballVelocity;

        GD.Print("Ball Reset");
    }

    public void OnGoalRBodyEntered(Node2D body){
        GD.Print("Goal Right");
        ResetBall();
    }
 
    public void OnGoalLBodyEntered(Node2D body){
        GD.Print("Goal Left");
        ResetBall();
    }
	
	private Tuple<int, int> GetRandomDirection(){
        Random random = new Random();

        // Generate a random angle in radians
        double angle = random.NextDouble() * 2 * Math.PI;

        // Convert the angle to a unit vector
        int x = (int)Math.Round(Math.Cos(angle));
        int y = (int)Math.Round(Math.Sin(angle));

        return Tuple.Create(x, y);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){

	}

}
