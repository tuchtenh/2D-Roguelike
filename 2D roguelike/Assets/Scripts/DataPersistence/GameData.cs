using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class GameData
{
    public int maxHealth;
    public int currentHealth;
    public float attackRange;
    public int attackDamage;
    public float attackRate;
    public Vector3 position;


    // default values for when the game starts without loaded data
    public GameData()
    {
        maxHealth = 100;
        currentHealth = 80;
        attackRange = 0.5f;
        attackDamage = 20;
        attackRate = 1;

        position = Vector3.zero; ;
    }
}
