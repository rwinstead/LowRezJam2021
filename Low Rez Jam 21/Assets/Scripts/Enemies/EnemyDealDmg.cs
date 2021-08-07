using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDmg : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().takeDamage();
        }
    }

}
