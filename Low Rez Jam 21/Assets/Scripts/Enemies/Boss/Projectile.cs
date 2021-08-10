using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 shootDir;
    public float moveSpeed = 30f;
    public float knockbackForce = 20f;
    bool alreadyHitPlayer = false;

    public void setDirection(Vector3 direction)
    {
        shootDir = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !alreadyHitPlayer)
        {
            alreadyHitPlayer = true;
            GameObject player = collision.gameObject;
            Vector2 knockDirection = (player.transform.position - transform.position).normalized;

            player.GetComponent<Health>().takeDamage();
            player.GetComponent<Rigidbody2D>().AddForce(knockDirection * knockbackForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }

    }


}
