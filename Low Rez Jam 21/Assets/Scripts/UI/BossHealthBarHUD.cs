using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarHUD : MonoBehaviour
{

    public GameObject BossHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        BossHealthBar.SetActive(false);
        EnemyHitManager.bossHealthChange += updateBossHealthBarHUD;
        Health.playerRespawn += disableBossHealthBar;
        CathedralExterior.bossArenaTeleport += enableBossHealthBar;
    }

   void updateBossHealthBarHUD(float val)
    {
        //Debug.Log(val);
        BossHealthBar.GetComponent<Slider>().value = val;
    }

    void enableBossHealthBar()
    {
        BossHealthBar.SetActive(true);
    }

    void disableBossHealthBar()
    {
        BossHealthBar.SetActive(false);
        BossHealthBar.GetComponent<Slider>().value = 1;
    }
}
