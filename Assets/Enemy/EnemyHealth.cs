using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Vidas máximas del enemigo
    private int currentHealth; // Vidas actuales del enemigo
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer
    public int experienceReward = 20; // Puntos de experiencia al morir

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //StartCoroutine(DamageFlashCoroutine());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DamageFlashCoroutine()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        Debug.Log("Enemigo eliminado!");

        // Aumentar la experiencia del jugador
        if (Player.Instance != null)
        {
            Player.Instance.AddExperience(experienceReward);
        }

        Destroy(gameObject);
    }
}
