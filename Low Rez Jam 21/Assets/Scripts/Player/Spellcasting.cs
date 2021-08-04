using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcasting : MonoBehaviour
{

    public Transform spellPrefab1;
    public Vector3 offset1;

    public MovementController movementC;

    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown("q") && movementC.m_Grounded)
        {
            Instantiate(spellPrefab1, new Vector3(transform.position.x + offset1.x, transform.position.y + offset1.y, transform.position.z + offset1.z), transform.rotation);
        }

        anim.SetBool("Attacking", false);

        if (Input.GetKeyDown("e"))
        {
            anim.SetBool("Attacking", true);
        }
    

    }
}
