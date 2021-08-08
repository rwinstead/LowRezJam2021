using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightActivateHitbox : MonoBehaviour
{
    public KnightAttackInRange knight;
    public void ActivateHitbox()
    {
        knight.ActivateHitBox();
    }
}
