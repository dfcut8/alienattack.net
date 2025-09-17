using Godot;
using Godot.Collections;

public partial class EnemySpawner : Node2D
{
    [Export]
    private PackedScene enemyScene;

    [Export]
    private int maxEnemies = 30;

    [Export] private PackedScene pathEnemyScene;

    private Array<Node> positions;
    private int currentEnemy;
    private Timer spawnNormalEnemiesTimer;
    private Timer spawnPathEnemiesTimer;

    public override void _Ready()
    {
        spawnNormalEnemiesTimer = GetNode<Timer>("SpawnNormalEnemiesTimer");
        spawnPathEnemiesTimer = GetNode<Timer>("SpawnPathEnemiesTimer");
        spawnNormalEnemiesTimer.Timeout += SpawnEnemy;
        spawnPathEnemiesTimer.Timeout += SpawnEnemyPath;
        positions = GetNode<Node2D>("Positions").GetChildren();
    }

    private void SpawnEnemy()
    {
        if (currentEnemy >= maxEnemies)
        {
            spawnNormalEnemiesTimer._ExitTree();
            return;
        }
        var instance = enemyScene.Instantiate() as Enemy;
        AddChild(instance);
        instance?.Position = ((Marker2D)positions.PickRandom()).Position;
        currentEnemy++;
    }
    
    private void SpawnEnemyPath()
    {
        var instance = pathEnemyScene.Instantiate();
        AddChild(instance);
    }
}
