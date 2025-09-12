using Godot;

public partial class Game : Node2D
{
    [Export]
    private Area2D deathZone;

    public override void _Ready()
    {
        GameEventHub.PlayerDied += OnPlayerDied;
        deathZone.AreaEntered += (Area2D a) =>
        {
            GD.Print($"Deathzone: Collided with: {a.Name}");
            a.QueueFree();
        };
    }
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("global_reset_level"))
        {
            GetTree().ReloadCurrentScene();
        }
    }

    private void OnPlayerDied()
    {
        GD.Print("From Game: OnPlayerDied");
    }

    protected override void Dispose(bool disposing)
    {
        GameEventHub.PlayerDied -= OnPlayerDied;
    }
}
