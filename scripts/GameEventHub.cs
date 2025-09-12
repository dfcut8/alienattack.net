using System;

public static class GameEventHub
{
    // Parameter: int - remaining lives
    public static Action PlayerDied;

    // Parameter: int - points to add to score
    public static Action<int> EnemyDied;
}
