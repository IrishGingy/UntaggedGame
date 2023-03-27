using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    float moveSpeed = 3f;
    Collider2D collider;
    //Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // instead of using a tag, the player has an identifiable PlayerController script attached.
        player = FindObjectOfType<PlayerController>().transform;
        collider = GetComponent<Collider2D>();
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //collider.Raycast(direction)
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Vector2 direction = (-player.position - transform.position)/2;
        Vector2 direction = transform.TransformDirection(Vector2.right) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }
}
