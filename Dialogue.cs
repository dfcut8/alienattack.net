using Godot;

public partial class Dialogue : Control
{

    [Export]
    private PackedScene[] actors;

    public override async void _Ready()
    {
        foreach (var item in actors)
        {
            var instance = item.Instantiate() as Actor;
            instance.Visible = false;
            AddChild(instance);
        }
        var actor1 = GetNode<Actor>("Actor");
        // await Task.Delay(3000);
        actor1.Visible = true;
        GD.Print("Starting ChangeColor");
        // _ = actor1.ChangeColor();
        GD.Print("Starting Move");
        _ = actor1.Move(GetNode<ReferenceRect>("ReferenceRect"));

        // Tweening text
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(GetNode<RichTextLabel>(
            "DialogPopup/PanelContainer/RichTextLabel"),
        "visible_ratio",
        1.0f,
        5.0f);
        await ToSignal(tween, Tween.SignalName.Finished);
    }
}
