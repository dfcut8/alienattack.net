using Godot;

public partial class Enemy : Area2D
{
    [Export]
    private float speed = 100;
    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition = new Vector2(GlobalPosition.X - speed * (float)delta, GlobalPosition.Y);
    }

    public void Die()
    {
        QueueFree();
    }
}
