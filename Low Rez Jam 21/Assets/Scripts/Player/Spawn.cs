using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Transform initialSpawn;
    public Transform activeSpawn;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = initialSpawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
