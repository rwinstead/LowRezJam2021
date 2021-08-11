using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneYellowEffect : MonoBehaviour
{
    public CircleCollider2D col;

    public void ShockEnemies()
    {
        col.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit with freeze");
            collision.gameObject.GetComponent<EnemyHitManager>().FreezeEnemy();
        }
    }
}
