using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerCombat : MonoBehaviour, IDataPersistence
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int maxHealth = 100;
    public int currentHealth;
    public float attackRange = 1f;
    public int attackDamage = 10;
    public float attackRate = 1f;

    float nextAttackTime = 0f;

    public PlayerHealthBar playerHealthBar;

    void Start()
    {
        playerHealthBar.SetPlayerMaxHealth(maxHealth);
        playerHealthBar.SetPlayerHealth(currentHealth);
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                PlayerTakeDamage(5);
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                PlayerHeal(5);
            }
        }
        
    }

    void Attack()
    {
        // Attack animation
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }

    public void PlayerTakeDamage(int damage)
    {
        //animator.SetTrigger("hit");

        //SpawnDamageText();

        currentHealth -= damage;
        playerHealthBar.SetPlayerHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Player dead");
    }

    public void PlayerHeal(int damage)
    {
        //animator.SetTrigger("hit");

        //SpawnDamageText();

        currentHealth += damage;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerHealthBar.SetPlayerHealth(currentHealth);
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void LoadData(GameData data)
    {
        this.maxHealth = data.maxHealth;
        this.currentHealth = data.currentHealth;
        this.attackRange = data.attackRange;
        this.attackDamage = data.attackDamage;
        this.attackRate = data.attackRate;
        this.transform.position = data.position;
    }

    public void SaveData(ref GameData data)
    {
        data.maxHealth = this.maxHealth;
        data.currentHealth = this.currentHealth;
        data.attackRange = this.attackRange;
        data.attackDamage = this.attackDamage;
        data.attackRate = this.attackRate;
        data.position = this.transform.position;
    }
}
