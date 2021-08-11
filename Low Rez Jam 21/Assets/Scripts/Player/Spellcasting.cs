using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcasting : MonoBehaviour
{

    public Transform spellPrefab1;
    public Transform spellPrefab2;
    public Transform spellPrefab3;
    public Vector3 offset1;

    public MovementController movementC;

    public Animator anim;

    private bool canCast = true;

    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;

    public ParticleSystem attackParticles;

    bool canAttack = true;


    //RuneIDs   Blue -> 1  Yellow -> 2  Green -> 3
    public bool blueRuneUnlocked = false;
    public bool greenRuneUnlocked = false;
    public bool yellowRuneUnlocked = false;
    public int activeRune = 0;
    public static Action<int> activateRune;

    bool[] spellsUnlocked = new bool[] { false, false, false };
    Transform[] SpellPrefabs = new Transform[3];

    private void Start()
    {
        SpellAnimationCallback.spellStarted += spellStartAnimation;
        SpellAnimationCallback.spellEnded += spellEndAnimation;

        AttackAnimationCallback.attackStarted += attackStartAnimation;
        AttackAnimationCallback.attackEnded += attackEndAnimation;

        ChestOpenTrigger.unlockRune += unlockRuneCasting;

        SpellPrefabs[0] = spellPrefab1;
        SpellPrefabs[1] = spellPrefab2;
        SpellPrefabs[2] = spellPrefab3;

    }

    private void OnDestroy()
    {
        SpellAnimationCallback.spellStarted -= spellStartAnimation;
        SpellAnimationCallback.spellEnded -= spellEndAnimation;

        AttackAnimationCallback.attackStarted -= attackStartAnimation;
        AttackAnimationCallback.attackEnded -= attackEndAnimation;

        ChestOpenTrigger.unlockRune -= unlockRuneCasting;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeActiveSpell();
        }

        if (Input.GetKeyDown("q") && movementC.m_Grounded && canCast && activeRune != 0)
        {
            CastActiveSpell();
        }

        anim.SetBool("Attacking", false);
        anim.SetBool("JumpAttack", false);

        if (Input.GetKeyDown("e") && movementC.m_Grounded && canAttack)
        {
            anim.SetBool("Attacking", true);
            Attack();
        }

        if (Input.GetKeyDown("e") && !movementC.m_Grounded && canAttack)
        {
            anim.SetBool("JumpAttack", true);
            Attack();
        }

    }

    void ChangeActiveSpell()
    {
        if (activeRune == 0) return;

        int index = activeRune - 1;

        for(int i = 0; i < 3; i++)
        {
            index++;
            if (index > 2) index = 0;
            if (spellsUnlocked[index])
            {
                activeRune = index + 1;
                activateRune?.Invoke(activeRune);
                break;
            }
        }
    }

    void CastActiveSpell()
    {
        Transform ActiveSpell = SpellPrefabs[activeRune - 1];
        Instantiate(ActiveSpell, new Vector3(transform.position.x + offset1.x, transform.position.y + offset1.y, transform.position.z + offset1.z), transform.rotation);
    }

    void Attack()
    {

        attackParticles.Play();

       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.gameObject.GetComponent<EnemyHitManager>().TakeDamage(1);
        }

    }

    void spellStartAnimation()
    {
        anim.SetBool("BlueRuneCast", true);
        canCast = false;
    }

    void spellEndAnimation()
    {
        anim.SetBool("BlueRuneCast", false);
        canCast = true;
    }

    void attackStartAnimation()
    {
        canAttack = false;
    }

    void attackEndAnimation()
    {
        canAttack = true;
    }

    void unlockRuneCasting(int RuneID)
    {
        if (RuneID == -1)
        {
            Debug.Log("No ID passed");
        }
        if (RuneID == 1)
        {
            blueRuneUnlocked = true;
            activeRune = 1;
            activateRune?.Invoke(1);
            spellsUnlocked[0] = true;
        }
        if (RuneID == 2)
        {
            yellowRuneUnlocked = true;
            activeRune = 2;
            activateRune?.Invoke(2);
            spellsUnlocked[1] = true;
        }
        if (RuneID == 3)
        {
            greenRuneUnlocked = true;
            activeRune = 3;
            activateRune?.Invoke(3);
            spellsUnlocked[2] = true;
        }
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
