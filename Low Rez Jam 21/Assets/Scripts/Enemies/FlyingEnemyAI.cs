using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public Transform enemyGfx;

    public SpriteRenderer enemySprite;

    Seeker seeker;
    Rigidbody2D rb;

    public float UpdatePathRate =  .5f;

    public bool canMove = true;

    public GameObject frostParticles;


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
        StartCoroutine("Freeze");
    }

    public IEnumerator Freeze()
    {
        canMove = false;
        enemySprite.color = new Color(0, 0, 1, 1);
        frostParticles.SetActive(true);

        yield return new WaitForSeconds(5);

        canMove = true;
        enemySprite.color = new Color(1, 1, 1, 1);
        frostParticles.SetActive(false);
    }

}
