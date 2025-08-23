using System.Threading.Tasks;

using Godot;

public partial class Actor : TextureRect
{
    public async Task ChangeColor()
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "modulate", Colors.Red, 3f);
        // .SetTrans(Tween.TransitionType.Bounce);
        await ToSignal(tween, Tween.SignalName.Finished);
    }

    public async Task Move(ReferenceRect target)
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "position", target.Position, 2f)
            .SetTrans(Tween.TransitionType.Elastic);
        // .SetEase(Tween.EaseType.In);
        await ToSignal(tween, Tween.SignalName.Finished);
    }
}
