using UnityEngine;
using System;
public class Health : MonoBehaviour
{
    bool isDead = false;
    public Action onDeath;
    public float maxHP = 100f;
    float hp;
    public float CurrentHP => hp;
    void Start()
    {
        hp = maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        hp -= damage;
        Debug.Log("HP: " + hp);

        if (hp <= 0)
        {
            Debug.Log("DEAD");
            Die();
        }
    }
    public void Heal(float healAmount)
    {
        if (isDead) return;
        hp += healAmount;
        if (hp > maxHP) hp = maxHP;
        Debug.Log("HP: " + hp);
    }

    void Die()
    {
        onDeath?.Invoke();
        isDead = true;
    }
}