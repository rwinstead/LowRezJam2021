using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public Transform[] waypoints;
    //Can store them here if we want the knight to only react to specific waypoints

    bool patrolling = true;

    public float walkingSpeed = 3f;

    Rigidbody2D rb;

    public bool canMove = true;

    public EnemyHitManager hitManager;

    public bool freezing = false;

    public SpriteRenderer enemySprite;

    public GameObject frostParticles;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hitManager.isFrozen)
        {
            Frozen();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patrolling)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(walkingSpeed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Flip()
    {
        patrolling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkingSpeed *= -1;
        patrolling = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Waypoint"))
        {
            Flip();
        }
    }

    public void Frozen()
    {
        if (!freezing)
        {
            Debug.Log("Calling frozen funtino");
            StartCoroutine("Freeze");
        }

    }

    public IEnumerator Freeze()
    {
        freezing = true;
        canMove = false;
        enemySprite.color = new Color(0.050f, 0.725f, 0.992f, 1);
        frostParticles.SetActive(true);
        anim.speed = 0;

        yield return new WaitForSeconds(5);

        anim.speed = 1;
        freezing = false;
        canMove = true;
        enemySprite.color = new Color(1, 1, 1, 1);
        frostParticles.SetActive(false);
        hitManager.isFrozen = false;
    }


}
