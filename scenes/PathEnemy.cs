using Godot;
using System;

public partial class PathEnemy : Path2D
{
    [Export] private float speed;
    private PathFollow2D pathFollow;
    private Area2D follower;

    public override void _Ready()
    {
        pathFollow = GetNode<PathFollow2D>("PathFollow2D");
        follower = GetNode<Area2D>("PathFollow2D/Follower");
    }

    public override void _PhysicsProcess(double delta)
    {
        pathFollow.Progress += (float)delta * speed;
        if (pathFollow.Progress >= 1)
        {
            follower.QueueFree();
        }
            
    }
}
