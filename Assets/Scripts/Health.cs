using UnityEngine;
using System;
public class Health : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitSound;
    bool isDead = false;
    public Action onDeath;
    public float maxHP = 100f;
    float hp;
    public ScreenFX screenFX;
    public float CurrentHP => hp;
    void Start()
    {
        hp = maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        hp -= damage;
        if (screenFX != null)
            screenFX.DamageFlash();
        if (audioSource != null && hitSound != null)
            audioSource.PlayOneShot(hitSound);
        Debug.Log("HP: " + hp);

        if (hp <= 0f)
        {
            hp = 0f;
            Die();
        }
    }
    public void Heal(float healAmount)
    {
        if (isDead) return;
        hp += healAmount;
        if (screenFX != null)
            screenFX.HealFlash();
        if (hp > maxHP) hp = maxHP;
        Debug.Log("HP: " + hp);
    }

    void Die()
    {
        onDeath?.Invoke();
        isDead = true;
    }
}