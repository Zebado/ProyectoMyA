using UnityEngine;

public class Memento
{
    public Vector3 PlayerPosition { get; private set; }
    public int PlayerHealth { get; private set; }

    public Memento(Vector3 position, int health)
    {
        PlayerPosition = position;
        PlayerHealth = health;
    }
}
