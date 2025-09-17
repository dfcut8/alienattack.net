using Godot;

public partial class ObjectType1 : Area2D
{
    public override void _Ready()
    {
        InputPickable = true;
        MouseEntered += OnMouseEntered;
        MouseExited += OnMouseExited;
    }

    private void OnMouseExited()
    {
        GD.Print("Mouse exited the area!");
        Modulate = new Color(1, 1, 1);
    }

    private void OnMouseEntered()
    {
        GD.Print("Mouse entered the area!");
        Modulate = new Color(2, 2, 2);
    }

    protected override void Dispose(bool disposing)
    {
        MouseEntered -= OnMouseEntered;
        MouseExited -= OnMouseExited;
    }
}
