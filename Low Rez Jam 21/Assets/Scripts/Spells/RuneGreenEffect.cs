using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneGreenEffect : MonoBehaviour
{
    public CircleCollider2D col;

    public void PoisonEnemies()
    {
        col.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHitManager>().Poison();
        }
    }
}
