using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = .25f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public Transform enemyGfx;

    public SpriteRenderer enemySprite;

    Seeker seeker;
    Rigidbody2D rb;

    public float UpdatePathRate =  .5f;

    public bool canMove = false;
    private bool freezing = false;

    public Animator batAnim;

    public GameObject frostParticles;

    public Collider2D col;

    public EnemyHitManager hitManager;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, UpdatePathRate);
     
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if (hitManager.isFrozen)
        {
            Frozen();
        }

        if(hitManager.currentHealth <= 0)
        {
            canMove = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if (canMove)
        {
            rb.AddForce(force);
        }

        else
        {
            rb.velocity = Vector2.zero;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyGfx.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
           enemyGfx.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void Frozen()
    {
        if (!freezing)
        {
            StartCoroutine("Freeze");
        }

    }

    public IEnumerator Freeze()
    {
        freezing = true;
        canMove = false;
        enemySprite.color = new Color(0, 0, 1, 1);
        frostParticles.SetActive(true);
        batAnim.speed = 0;

        yield return new WaitForSeconds(5);

        batAnim.speed = 1;
        freezing = false;
        canMove = true;
        enemySprite.color = new Color(1, 1, 1, 1);
        frostParticles.SetActive(false);
        hitManager.isFrozen = false;
    }

}
