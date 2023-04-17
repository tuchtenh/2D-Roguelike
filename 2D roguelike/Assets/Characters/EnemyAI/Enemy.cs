using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;

    public GameObject damageText;

    public Animator animator;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hit");
        RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();

        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.GetComponent<Collider2D>().transform.position);

        Canvas canvas = GameObject.FindAnyObjectByType<Canvas>();
        textTransform.SetParent(canvas.transform);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Skeleton>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        GetComponentInChildren<Canvas>().enabled = false;
    }

}
