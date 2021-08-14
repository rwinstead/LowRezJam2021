using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KnightAttackInRange : MonoBehaviour
{

    public Animator anim;

    public bool canAttack = true;

    public PatrolAI patrolai;

    public Transform attackPoint;

    public float attackRange = 1f;

    public float knockbackForce = 3f;

    GameObject parent;

    public float attackCooldown = 1.5f;


    public LayerMask playerLayer;

    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack && !patrolai.freezing)
        {
            Attack();
        }
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine("PauseWalking");
        StartCoroutine("PauseAttacking");
        

    }

    public void ActivateHitBox()
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if(hitPlayer != null)
        {
            //Debug.Log("Hit " + hitPlayer.gameObject.name);

            Vector2 direction = (hitPlayer.transform.position - parent.transform.position).normalized;

            hitPlayer.gameObject.GetComponent<Health>().takeDamage();
            hitPlayer.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        }

        
        
    }

    public IEnumerator PauseWalking()
    {
        patrolai.canMove = false;
        yield return new WaitForSeconds(1);
        if (!patrolai.freezing)
        {
            patrolai.canMove = true;
        }
    }
    public IEnumerator PauseAttacking()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
