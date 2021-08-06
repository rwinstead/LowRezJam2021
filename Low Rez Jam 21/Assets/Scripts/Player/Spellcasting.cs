using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellcasting : MonoBehaviour
{

    public Transform spellPrefab1;
    public Vector3 offset1;

    public MovementController movementC;

    public Animator anim;

    private bool canCast = true;

    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;

    private void Start()
    {
        SpellAnimationCallback.spellStarted += spellStartAnimation;
        SpellAnimationCallback.spellEnded += spellEndAnimation;
    }

    private void OnDestroy()
    {
        SpellAnimationCallback.spellStarted -= spellStartAnimation;
        SpellAnimationCallback.spellEnded -= spellEndAnimation;
    }

    void Update()
    {
        if (Input.GetKeyDown("q") && movementC.m_Grounded && canCast)
        {
            Instantiate(spellPrefab1, new Vector3(transform.position.x + offset1.x, transform.position.y + offset1.y, transform.position.z + offset1.z), transform.rotation);
        }

        anim.SetBool("Attacking", false);
        anim.SetBool("JumpAttack", false);

        if (Input.GetKeyDown("e") && movementC.m_Grounded)
        {
            anim.SetBool("Attacking", true);
            Attack();
        }

        if (Input.GetKeyDown("e") && !movementC.m_Grounded)
        {
            anim.SetBool("JumpAttack", true);
            Attack();
        }

    }

    void Attack()
    {
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

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
