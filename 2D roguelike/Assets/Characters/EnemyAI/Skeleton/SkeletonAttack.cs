using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    float nextAttackTime = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {      
            InvokeRepeating("StartAttacking", 0f, 3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("StartAttacking");
            gameObject.GetComponentInParent<Skeleton>().StopAttack();
        }
    }

    void StartAttacking()
    {
        gameObject.GetComponentInParent<Skeleton>().Attack();
        nextAttackTime = Time.time + 1f / gameObject.GetComponentInParent<Skeleton>().attackRate;
    }
}
