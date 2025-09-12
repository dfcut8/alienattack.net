using Godot;

public partial class Ui : Control
{
    private Label scoreLabel;
    private Label livesLabel;
    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("%Score");
        livesLabel = GetNode<Label>("%Lives");
    }

    public void UpdateScore(int score)
    {
        scoreLabel.Text = score.ToString();
    }

    public void UpdateLives(int lives)
    {
        livesLabel.Text = lives.ToString();
    }
}
