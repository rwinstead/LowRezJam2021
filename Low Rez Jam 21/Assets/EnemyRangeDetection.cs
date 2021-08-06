using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeDetection : MonoBehaviour
{
    Collider2D col;
    public FlyingEnemyAI enemyAI;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            col.enabled = false;
            enemyAI.canMove = true;
            enemyAI.batAnim.SetBool("PlayerInRange", true);
        }
    }
}
