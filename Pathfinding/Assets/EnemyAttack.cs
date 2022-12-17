using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    AIDestinationSetter destinationScript;
    Seeker seeker;
    Transform target;
    bool bitingPlayer;

    private void Start()
    {
        destinationScript = gameObject.GetComponentInParent<AIDestinationSetter>();
        target = destinationScript.target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !bitingPlayer)
        {
            bitingPlayer = true;
            Debug.Log("Biting!");
            StartCoroutine("Bite");
        }
    }

    IEnumerator Bite()
    {
        while (bitingPlayer)
        {
            yield return new WaitForSeconds(1f);
            if (!bitingPlayer) break;
            Debug.Log("biting again!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && bitingPlayer)
        {
            bitingPlayer = false;
            Debug.Log("NOT BITING ANYMORE");
        }
    }

    private void Update()
    {
        /*if (path == null)
        {
            return;
        }

        // we've reached the end of the path.
        if (currentWaypoint >= path.vectorPath.Count)
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

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }*/
    }
}
