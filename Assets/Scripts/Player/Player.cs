using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private int _currentHealth;
    private int _damagePerHealth;

    private void ReduceHealth(int health, int currentHealth, int damage)
    {
        health = currentHealth - damage;
    }
}
