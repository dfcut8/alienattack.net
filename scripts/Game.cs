using Godot;

public partial class Game : Node2D
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("global_reset_level"))
        {
            GetTree().ReloadCurrentScene();
        }
    }
}
