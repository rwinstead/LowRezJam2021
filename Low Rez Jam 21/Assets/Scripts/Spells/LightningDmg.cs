using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDmg : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHitManager>().TakeDamage(4);
        }
    }
}
