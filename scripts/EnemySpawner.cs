using Godot;
using Godot.Collections;

public partial class EnemySpawner : Node2D
{
    [Export]
    private PackedScene enemyScene;

    [Export]
    private int maxEnemies = 30;

    private Array<Node> positions;
    private int currentEnemy;
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        timer.Timeout += spawnEnemy;
        positions = GetNode<Node2D>("Positions").GetChildren();
    }

    private void spawnEnemy()
    {
        if (currentEnemy >= maxEnemies)
        {
            timer._ExitTree();
            return;
        }
        var instance = enemyScene.Instantiate() as Enemy;
        AddChild(instance);
        instance.Position = ((Marker2D)positions.PickRandom()).Position;
        currentEnemy++;
    }
}
