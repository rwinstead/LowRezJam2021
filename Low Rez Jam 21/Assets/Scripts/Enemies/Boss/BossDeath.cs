using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{

	public float waitSecondsOnDeath = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
     	EnemyHitManager.bossDeath += bossDeathHandler;   
    }

    void bossDeathHandler()
    {
        StartCoroutine(waitOnBossDeath());
    }

    public IEnumerator waitOnBossDeath()
    {
        Debug.Log("Boss Dead, Waiting for Seconds "+waitSecondsOnDeath);
        yield return new WaitForSeconds(waitSecondsOnDeath);
        Debug.Log("LoadingScene Victory");
        SceneManager.LoadScene("Victory");
    }

}
