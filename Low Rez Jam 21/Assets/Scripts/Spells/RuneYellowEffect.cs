using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneYellowEffect : MonoBehaviour
{

    public Transform[] lightningBolts = new Transform[4];

    int spotToDestroy;

    public void ShockEnemies()
    {

        spotToDestroy = Random.Range(0, 4);

        lightningBolts[0].gameObject.SetActive(true);
        lightningBolts[1].gameObject.SetActive(true);
        lightningBolts[2].gameObject.SetActive(true);
        lightningBolts[3].gameObject.SetActive(true);

        lightningBolts[spotToDestroy].gameObject.SetActive(false);
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
