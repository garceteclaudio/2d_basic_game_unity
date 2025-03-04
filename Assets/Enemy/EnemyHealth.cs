using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Vidas máximas del enemigo
    private int currentHealth; // Vidas actuales del enemigo
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer

    void Start()
    {
        currentHealth = maxHealth; // Inicializar las vidas al máximo
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el SpriteRenderer
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir las vidas

        // Activar efecto de titileo
        StartCoroutine(DamageFlashCorutine());

        // Verificar si el enemigo ha muerto
        if (currentHealth <= 0)
        {
            Die(); // Llamar al método para eliminar al enemigo
        }
    }

    // Corrutina para el efecto de titileo en rojo
    private IEnumerator DamageFlashCorutine()
    {
        Color originalColor = spriteRenderer.color; // Guardar color original
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f); // Espera 0.5 f segundos
        spriteRenderer.color = originalColor; // Asegurar que vuelve al color original
    }

    // Método para eliminar al enemigo
    void Die()
    {
        Debug.Log("Enemigo eliminado!");
        Destroy(gameObject); // Destruir el GameObject del enemigo
    }
}
