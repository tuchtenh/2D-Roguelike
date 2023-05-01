using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Skeleton>().animator.SetBool("isAttacking", true);
            gameObject.GetComponentInParent<Skeleton>().SetAttacking(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Skeleton>().animator.SetBool("isAttacking", false);
        }
    }
}
