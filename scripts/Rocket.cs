using Godot;

namespace AlienAttack;

public partial class Rocket : Area2D
{
    [Export]
    public float speed = 500f;
    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition = new Vector2(GlobalPosition.X + speed * (float)delta, GlobalPosition.Y);
    }
}
