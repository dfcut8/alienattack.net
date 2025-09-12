using Godot;

public partial class GameOver : Control
{
    public override void _Ready()
    {
        var button = GetNode<Button>("%RetryButton");
        button.Pressed += OnRestartButtonPressed;
    }
    private void OnRestartButtonPressed()
    {
        GetTree().ReloadCurrentScene();
    }
}
