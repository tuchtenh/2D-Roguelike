using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    public Animator animator;
    public float moveSpeed = 500f;
    public DetectionZone detectionZone;
    Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (detectionZone.detectedObjects.Count > 0)
        {
            Vector2 direction = (detectionZone.detectedObjects[0].transform.position - transform.position ).normalized;
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
            else if (direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

}
