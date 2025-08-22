using Godot;

namespace AlienAttack;

public partial class Player : CharacterBody2D
{
    [Export]
    public float speed = 500f;

    [Export]
    public PackedScene rocketScene;

    [Export]
    public Node rocketContainer;

    public Vector2 viewPortSize;

    public override void _Ready()
    {
        viewPortSize = GetViewportRect().Size;
    }
    public override void _PhysicsProcess(double delta)
    {
        var moveVelocity = new Vector2();
        if (Input.IsActionPressed("player_move_right"))
        {
            moveVelocity.X += speed;
        }
        if (Input.IsActionPressed("player_move_left"))
        {
            moveVelocity.X += -speed;
        }
        if (Input.IsActionPressed("player_move_down"))
        {
            moveVelocity.Y += speed;
        }
        if (Input.IsActionPressed("player_move_up"))
        {
            moveVelocity.Y += -speed;
        }
        if (Input.IsActionJustPressed("player_fire"))
        {
            shoot();
        }
        if (Input.IsActionJustPressed("global_reset_level"))
        {
            die();
        }
        Velocity = moveVelocity;
        MoveAndSlide();
        GlobalPosition = GlobalPosition.Clamp(new Vector2(0f, 0f), viewPortSize);
    }

    private void die()
    {
        QueueFree();
    }

    private void shoot()
    {
        var instance = rocketScene.Instantiate() as Area2D;

        rocketContainer.AddChild(instance);
        instance.GlobalPosition = new Vector2(GlobalPosition.X + 50, GlobalPosition.Y);
    }
}
