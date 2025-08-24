using Godot;
using Godot.Collections;

public partial class EnemySpawner : Node2D
{
    [Export]
    private PackedScene enemyScene;

    private Array<Node> positions;
    private int currentPosition;
    private int maxEnemies = 20;
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
        instance.Position = ((Marker2D)positions[currentPosition]).Position;
        currentPosition++;
        currentEnemy++;
        if (currentPosition >= positions.Count)
        {
            currentPosition = 0;
        }
    }
}
