using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    int wallLayer = 7;
    public Transform target;
    public float lerpSpeed = 1.0f;

    private Vector3 offset;
    private bool following;
    private Vector3 targetPos;

    [SerializeField] Transform cam;

    private void Start()
    {
        if (target == null) return;

        offset = cam.position - target.position;
    }

    private void Update()
    {
        if (target == null) return;

        if (following)
        {
            targetPos = target.position + offset;
            cam.position = Vector3.Lerp(cam.position, targetPos, lerpSpeed * Time.deltaTime);
        }
        else
        {
            // lerp transition the camera to the nearest static preset camera position
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == wallLayer)
        {
            following = false;
            Debug.Log("Hit a wall!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == wallLayer)
        {
            following = true;
            Debug.Log("Stopped hitting a wall!");
        }
    }
}
