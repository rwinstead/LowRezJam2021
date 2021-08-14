using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKillAnimation : MonoBehaviour
{

    public Animator anim;

    public EnemyHitManager hitManager;

    bool triggered = false;

    private void Update()
    {
        if(hitManager.currentHealth <= 0 && !triggered)
        {
            TriggerAnimation();
            triggered = true;
        }
    }

    public void TriggerAnimation()
    {
        anim.SetTrigger("GhostDead");
    }

}
