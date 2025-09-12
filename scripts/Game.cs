using Godot;

public partial class Game : Node2D
{
    [Export]
    private Area2D deathZone;

    public int Score { get; private set; } = 0;

    private Ui ui;

    public override void _Ready()
    {
        ui = GetNode<Ui>("Ui");
        GameEventHub.PlayerDied += OnPlayerDied;
        GameEventHub.EnemyDied += OnEnemyDied;
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

    private void OnEnemyDied(int score)
    {
        Score += score;
        ui.UpdateScore(Score);
    }

    protected override void Dispose(bool disposing)
    {
        GameEventHub.PlayerDied -= OnPlayerDied;
        GameEventHub.EnemyDied -= OnEnemyDied;
    }
}
