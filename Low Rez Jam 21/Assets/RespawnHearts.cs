using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHearts : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Transform heart1Pos;
    public Transform heart2Pos;
    public Transform heart3Pos;

    public GameObject heartPrefab;

    void Start()
    {
        Health.playerRespawn += resetHearts;
    }

    private void OnDestroy()
    {
        Health.playerRespawn -= resetHearts;
    }

    public void resetHearts()
    {
        if(heart1 == null)
        {
            Instantiate(heartPrefab, heart1Pos.position, Quaternion.identity);
        }
        if (heart2 == null)
        {
            Instantiate(heartPrefab, heart2Pos.position, Quaternion.identity);
        }
        if (heart3 == null)
        {
            Instantiate(heartPrefab, heart3Pos.position, Quaternion.identity);
        }
    }

}
