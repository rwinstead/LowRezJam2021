using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBlueEffect : MonoBehaviour
{

    public CircleCollider2D col;

    public void FreezeEnemies()
    {
        Debug.Log("freezing enemies");

        col.enabled = true;

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy in freeze");
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy in freeze");
            Destroy(collision.gameObject);
        }
    }


}
