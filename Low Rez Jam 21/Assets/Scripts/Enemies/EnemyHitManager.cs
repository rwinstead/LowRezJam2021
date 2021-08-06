using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{
    FlyingEnemyAI flyingAI;

    public int maxHealth = 1;
    int currentHealth;

    private void Start()
    {
        flyingAI = GetComponent<FlyingEnemyAI>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void FreezeEnemy()
    {
        flyingAI.Frozen();
        Debug.Log("I WOrk?");
    }
}
