using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDmg : MonoBehaviour
{

    public float knockbackForce;

    public GameObject parent;

    private Vector2 direction;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<Health>().takeDamage();

            direction = (player.transform.position - parent.transform.position).normalized;
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            parent.GetComponent<Rigidbody2D>().AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
        }
    }

}
