using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneYellowEffect : MonoBehaviour
{
    public CircleCollider2D col;

    public Transform[] lightningBolts = new Transform[4];

    int spot1;
    int spot2;

    public void ShockEnemies()
    {
        spot1 = -1;
        spot2 = -1;
        while (spot1 == spot2)
        {
            spot1 = Random.Range(0, 4);
            spot2 = Random.Range(0, 4);
        }

        lightningBolts[spot1].gameObject.SetActive(true);
        lightningBolts[spot2].gameObject.SetActive(true);
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
