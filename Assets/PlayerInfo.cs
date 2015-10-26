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

    void OnColliderEnter2D(Collider2D collider)
    {
        //TODO: make damage more flexible ie. Different enemy types = different damage amounts
        string tag = collider.gameObject.tag;
        if (tag == "Enemy" || tag == "Debris")
        {
            health -= 10;
        }
    }
}
