using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Transform initialSpawn;
    public Transform activeSpawn;
    public GameObject player;

    public static Action updateCheckpoint;

    

    // Start is called before the first frame update
    void Start()
    {
        Health.playerRespawn += Respawn;
        player.transform.position = initialSpawn.position;
        activeSpawn = initialSpawn;
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Respawn();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            activeSpawn = collision.gameObject.transform;
            Debug.Log("Updating Respawn Point");
            updateCheckpoint?.Invoke();

        }
    }

    public void Respawn()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody2D>().angularVelocity = 0;
        player.transform.position = activeSpawn.position;

    }


}
