using Godot;

public partial class Ui : Control
{
    private Label scoreLabel;
    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("%Score");
    }

    public void UpdateScore(int score)
    {
        scoreLabel.Text = score.ToString();
    }
}
