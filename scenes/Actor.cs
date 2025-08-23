using System.Threading.Tasks;

using Godot;

public partial class Actor : TextureRect
{
    public async Task ChangeColor()
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "modulate", Colors.Red, 5.0f);
        tween.TweenCallback(Callable.From(QueueFree));
    }
}
