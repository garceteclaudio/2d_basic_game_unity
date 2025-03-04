using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    void Update()
    {
        // Detectar clic del mouse
        if (Input.GetMouseButtonDown(0)) // 0 = clic izquierdo
        {
            // Lanzar un rayo desde la cámara hacia la posición del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Verificar si el rayo golpea al enemigo
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
               
                // Obtener el componente EnemyHealth del enemigo
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                Debug.Log("Se hizo click sobre el enemigo !!!! Cantidad de vidas: "+ enemyHealth.GetCurrentHealth());
                // Si el enemigo tiene el componente, aplicar daño
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1); // Reducir una vida
                }
            }
        }
    }
}