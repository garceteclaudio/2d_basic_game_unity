using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // Da�o que hace la bala al enemigo

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        // Verificar si la bala colisiona con un objeto que tenga el tag "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Colision detectada!!!");

            // Obtener el componente EnemyHealth del enemigo
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            // Si el enemigo tiene el componente EnemyHealth, aplicar da�o
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destruir la bala despu�s de la colisi�n
            Destroy(gameObject);
        }
    }
}