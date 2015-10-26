using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
    int health = 100;

    public void Damage(int amount)
    {
        health -= amount;
    }

    public bool IsDead()
    {
        return health < 0;
    }
}
