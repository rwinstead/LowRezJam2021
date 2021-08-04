using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        SpellAnimationCallback.spellEnded += DestroyThis;
    }

    private void OnDestroy()
    {
        SpellAnimationCallback.spellEnded -= DestroyThis;
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
