using Godot;

namespace AlienAttack;

public partial class Rocket : Area2D
{
    [Export]
    public float speed = 500f;

    private Player player;
    public override void _Ready()
    {
        var notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleNotifier");
        notifier.ScreenExited += () => QueueFree();
        player = GetNode<Player>("/root/Game/Player");
        player.playerFired += onPlayerFired;
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D other)
    {
        GD.Print($"Hit! Other name: {other.Name}");
        if (other is Enemy e)
        {
            e.Die();
        }
        QueueFree();
    }

    private void onPlayerFired(int i)
    {
        GD.Print($"Processing event from: {Name}, value: {i}");
    }

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition = new Vector2(GlobalPosition.X + speed * (float)delta, GlobalPosition.Y);
    }

    protected override void Dispose(bool disposing)
    {
        player.playerFired -= onPlayerFired;
    }
}
