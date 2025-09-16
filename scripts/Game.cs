using Godot;

public partial class Game : Node2D
{
    [Export]
    private Area2D deathZone;

    [Export]
    private PackedScene gameOverScene;
    
    [Export]
    private AudioStreamPlayer enemyHitSound;
    
    [Export]
    private AudioStreamPlayer playerHitSound;

    public static int Lives { get; private set; } = 2;
    public int Score { get; private set; } = 0;

    private Ui ui;

    public override void _Ready()
    {
        ui = GetNode<Ui>("UiCanvas/Ui");
        ui.UpdateLives(Lives);
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

    private async void OnPlayerDied()
    {
        Lives--;
        ui.UpdateLives(Lives);
        playerHitSound.Play();
        if (Lives >= 0) return;
        await ToSignal(GetTree().CreateTimer(1.5f), SceneTreeTimer.SignalName.Timeout);
        var gameOverSceneInstance = gameOverScene.Instantiate();
        gameOverSceneInstance.ProcessMode = ProcessModeEnum.WhenPaused;
        GetNode("UiCanvas").AddChild(gameOverSceneInstance);
        var gameOverScreen = gameOverSceneInstance as GameOver;
        gameOverScreen?.UpdateScore(Score);
        GetTree().Paused = true;
    }

    private void OnEnemyDied(int score)
    {
        Score += score;
        enemyHitSound.Play();
        ui.UpdateScore(Score);
    }

    protected override void Dispose(bool disposing)
    {
        GameEventHub.PlayerDied -= OnPlayerDied;
        GameEventHub.EnemyDied -= OnEnemyDied;
    }
}
