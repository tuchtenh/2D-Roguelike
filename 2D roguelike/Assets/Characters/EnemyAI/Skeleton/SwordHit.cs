using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.GetComponentInParent<Skeleton>().IsAttacking())
        {
            damage = gameObject.GetComponentInParent<Skeleton>().attackDamage;
            collision.GetComponentInParent<PlayerCombat>().PlayerTakeDamage(damage);
        }
    }
}
