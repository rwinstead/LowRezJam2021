using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{

    public Transform BossSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
        CathedralExterior.bossArenaTeleport += activateBoss;
        Health.playerRespawn += resetBoss;

        this.gameObject.SetActive(false);
    }

    void activateBoss()
    {
        this.gameObject.SetActive(true);
    }

    void resetBoss()
    {
        this.gameObject.transform.position = BossSpawn.position;
        this.gameObject.SetActive(false);
    }
}
