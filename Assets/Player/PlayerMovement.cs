using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador
    public float moveSpeed = 5f;

    // Referencia al componente Rigidbody2D (si es un juego 2D)
    private Rigidbody2D rb;

    // Vector para almacenar la dirección del movimiento
    private Vector2 movement;

    void Start()
    {
        // Obtener el componente Rigidbody2D adjunto al GameObject
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // Suaviza el movimiento
    }

    void Update()
    {
        // Capturar la entrada del usuario en los ejes horizontal y vertical
        movement.x = Input.GetAxisRaw("Horizontal"); // Teclas A/D o Flechas Izquierda/Derecha
        movement.y = Input.GetAxisRaw("Vertical");   // Teclas W/S o Flechas Arriba/Abajo

        // Normalizar el vector de movimiento para evitar movimiento más rápido en diagonal
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // Mover el jugador solo si hay entrada del usuario
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}