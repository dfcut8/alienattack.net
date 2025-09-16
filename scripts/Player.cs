using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public float Speed = 500f;

    [Export]
    public Vector2 RespawnPosition = new Vector2(50, 250);

    [Export]
    public PackedScene RocketScene;

    [Export]
    public Node RocketContainer;

    public Vector2 viewPortSize;

    public Action<int> PlayerFired;

    private Sprite2D sprite;

    public override void _Ready()
    {
        sprite = GetNode<Sprite2D>("Sprite2D");
        viewPortSize = GetViewportRect().Size;
    }
    public override void _PhysicsProcess(double delta)
    {
        var moveVelocity = new Vector2();
        if (Input.IsActionPressed("player_move_right"))
        {
            moveVelocity.X += Speed;
        }
        if (Input.IsActionPressed("player_move_left"))
        {
            moveVelocity.X += -Speed;
        }
        if (Input.IsActionPressed("player_move_down"))
        {
            moveVelocity.Y += Speed;
        }
        if (Input.IsActionPressed("player_move_up"))
        {
            moveVelocity.Y += -Speed;
        }
        if (Input.IsActionJustPressed("player_fire"))
        {
            Shoot();
            PlayerFired?.Invoke(100);
        }

        Velocity = moveVelocity;
        MoveAndSlide();
        GlobalPosition = GlobalPosition.Clamp(new Vector2(0f, 0f), viewPortSize);
    }

    public void TakeDamage()
    {
        GameEventHub.PlayerDied?.Invoke();
        Position = RespawnPosition;
        sprite.Modulate = sprite.Modulate.Darkened(0.3f);
    }

    private void Shoot()
    {
        var instance = RocketScene.Instantiate() as Area2D;

        RocketContainer.AddChild(instance);
        instance?.GlobalPosition = new Vector2(GlobalPosition.X + 50, GlobalPosition.Y);
    }
}
