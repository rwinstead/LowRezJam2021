using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBySpell : MonoBehaviour
{
    public FlyingEnemyAI flyingAI;

    private void Start()
    {
        flyingAI = GetComponent<FlyingEnemyAI>();
    }
    public void FreezeEnemy()
    {
        flyingAI.Frozen();
        Debug.Log("I WOrk?");
    }
}
