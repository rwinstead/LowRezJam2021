using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivateHitbox : MonoBehaviour
{
    public BossAttackInRange boss;
    public void ActivateHitbox()
    {
        boss.ActivateHitBox();
    }
}
