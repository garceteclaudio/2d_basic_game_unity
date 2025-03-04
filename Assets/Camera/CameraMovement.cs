using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Suavizado del movimiento de la cámara
    public Vector3 offset; // Desplazamiento de la cámara respecto al jugador

    void Start()
    {
        // Buscar al jugador por su tag
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("No se encontró un objeto con el tag 'Player'.");
            }
        }

        // Establecer un desplazamiento inicial si no se ha definido
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcular la posición deseada de la cámara
            Vector3 desiredPosition = player.position + offset;

            // Suavizar el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualizar la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}