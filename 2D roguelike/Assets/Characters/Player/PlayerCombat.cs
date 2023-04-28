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

    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 0.01f;
    float nextAttackTime = 0f;

    public int playerCurrentHealth;
    public int playerMaxHealth = 100;
    public HealthBar healthBar;

    //void Start()
    //{
    //    playerCurrentHealth = playerMaxHealth;
    //    healthBar.SetMaxHealth(playerMaxHealth);
    //}


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
        this.playerMaxHealth = data.maxHealth;
        this.playerCurrentHealth = data.currentHealth;
        this.attackRange = data.attackRange;
        this.attackDamage = data.attackDamage;
        this.attackRate = data.attackRate;

        this.transform.position = data.position;
    }

    public void SaveData(ref GameData data)
    {
        data.maxHealth = this.playerMaxHealth;
        data.currentHealth = this.playerCurrentHealth;
        data.attackRange = this.attackRange;
        data.attackDamage = this.attackDamage;
        data.attackRate = this.attackRate;

        data.position = this.transform.position;
    }
}
