using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pointA; // Punto inicial de patrullaje
    public Transform pointB; // Punto final de patrullaje
    public float patrolSpeed = 2f; // Velocidad de patrullaje
    public float chaseSpeed = 4f; // Velocidad de persecución
    public float detectionRange = 5f; // Rango de detección del jugador

    private Transform targetPoint; // Punto actual al que se dirige
    private Transform player; // Referencia al jugador
    private bool isChasing = false; // ¿Está persiguiendo al jugador?

    void Start()
    {
        // Inicializar el punto de destino
        targetPoint = pointA;

        // Buscar al jugador por su tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Calcular la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Perseguir al jugador
            isChasing = true;
            ChasePlayer();
        }
        else
        {
            // Patrullar
            isChasing = false;
            Patrol();
        }
    }

    void Patrol()
    {
        // Moverse hacia el punto de destino
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        // Cambiar de punto de destino si se alcanza el actual
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    void ChasePlayer()
    {
        // Moverse hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    // Dibujar el rango de detección en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}