using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnCollision : MonoBehaviour
{
    public float knockbackForce;

    private Vector2 direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<Health>().takeDamage();

            direction = (player.transform.position - transform.position).normalized;
            Debug.Log(direction);

            player.GetComponent<MovementController>().StartKnockBack(direction * knockbackForce);

            //player.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
        }
    }

}
