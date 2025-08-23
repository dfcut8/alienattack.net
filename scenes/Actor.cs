using System.Threading.Tasks;

using Godot;

public partial class Actor : TextureRect
{
    public async Task ChangeColor()
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "modulate", Colors.Red, 3.0f);
        await ToSignal(tween, Tween.SignalName.Finished);
        // return Task.CompletedTask;
    }

    public async Task Move(ReferenceRect target)
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "position", target.Position, 3.0f);
        await ToSignal(tween, Tween.SignalName.Finished);
    }
}
