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
        await Task.Delay(3000);
        var actor1 = GetNode<Actor>("Actor");
        actor1.Visible = true;
        await actor1.ChangeColor();
        await actor1.Move(GetNode<ReferenceRect>("ReferenceRect"));
    }
}
