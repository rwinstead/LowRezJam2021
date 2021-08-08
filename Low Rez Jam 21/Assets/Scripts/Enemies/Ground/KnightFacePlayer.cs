using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFacePlayer : MonoBehaviour
{
    public Transform knight;
    public PatrolAI patrol;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Vector2 direction = player.transform.position - knight.position;

            if (direction.x > 0 && knight.localScale.x < 0)
            {
                patrol.Flip();
            }

            else if (direction.x < 0 && knight.localScale.x > 0)
            {
                patrol.Flip();
            }
        }
    }
}
