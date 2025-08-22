using Godot;

namespace AlienAttack;

public partial class Rocket : Area2D
{
    [Export]
    public float speed = 500f;
    public override void _Ready()
    {
        var notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleNotifier");
        notifier.ScreenExited += () => QueueFree();
    }
    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition = new Vector2(GlobalPosition.X + speed * (float)delta, GlobalPosition.Y);
    }
}
