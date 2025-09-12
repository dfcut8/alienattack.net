using System;

public static class GameEventHub
{
    public static Action PlayerDied;

    // Parameter: int - points to add to score
    public static Action<int> EnemyDied;
}
