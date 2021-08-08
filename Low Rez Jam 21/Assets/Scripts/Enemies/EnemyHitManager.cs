using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{

    public int maxHealth = 1;
    int currentHealth;

    public bool isFrozen = false;

    private void Start()
    {

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
        isFrozen = true;
        Debug.Log("I am froezn now");
    }
}
