using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> powerups;

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
        SpawnDamageText();
        animator.SetTrigger("hit");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void SpawnDamageText()
    {
        RectTransform textTransform = Instantiate(damageText).GetComponent<RectTransform>();

        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.GetComponent<Collider2D>().transform.position);

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        textTransform.SetParent(canvas.transform);

        //Instantiate(damageText, transform.position, Quaternion.identity);
    }
    void Die()
    {
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Skeleton>().enabled = false;
        GetComponent<Enemy>().enabled = false;
        GetComponentInChildren<Canvas>().enabled = false;
        Destroy(gameObject, 5f);

        int randomIndex = Random.Range(0, powerups.Count);
        GameObject powerup = powerups[randomIndex];
        GameObject powerupObj = Instantiate(powerup, transform.position, Quaternion.identity);
        Destroy(powerupObj, 10f); // Destroy power-up after 10 seconds
    }

}
