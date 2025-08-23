using System.Threading.Tasks;

using Godot;

public partial class Dialogue : Control
{

    [Export]
    private PackedScene[] actors;

    public override void _Ready()
    {
        foreach (var item in actors)
        {
            var instance = item.Instantiate() as Actor;
            instance.Visible = false;
            AddChild(instance);
        }
    }

    public override async void _PhysicsProcess(double delta)
    {
        var actor1 = GetNode<Actor>("Actor");
        await Task.Delay(3000);
        actor1.Visible = true;
        GD.Print("Starting ChangeColor");
        _ = actor1.ChangeColor();
        GD.Print("Starting Move");
        _ = actor1.Move(GetNode<ReferenceRect>("ReferenceRect"));
    }
}
