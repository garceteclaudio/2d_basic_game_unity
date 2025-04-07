using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform eye; // Objeto "eye" que apunta la dirección
    [SerializeField] private float eyeOffset = 0.5f;

    private Rigidbody2D rb;
    private Vector2 currentDirection;
    private Vector2 lastNonZeroDirection = Vector2.right; // Dirección por defecto (derecha)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    public void SetMovement(Vector2 direction)
    {
        currentDirection = direction;

        // Guardar la última dirección no-cero para el eye cuando el jugador deja de moverse
        if (direction != Vector2.zero)
        {
            lastNonZeroDirection = direction;
        }

        UpdateEyePosition();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + currentDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateEyePosition()
    {
        if (eye == null) return;

        // Usar lastNonZeroDirection si currentDirection es cero
        Vector2 directionToUse = currentDirection != Vector2.zero ? currentDirection : lastNonZeroDirection;

        // Posición del eye (siempre visible)
        Vector2 newPosition = (Vector2)transform.position + directionToUse * eyeOffset;
        eye.position = newPosition;

        // Rotación del eye (siempre actualizada)
        float angle = Mathf.Atan2(directionToUse.y, directionToUse.x) * Mathf.Rad2Deg;
        eye.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Método público para obtener la dirección actual del eye (útil para el disparo)
    public Vector2 GetEyeDirection()
    {
        return lastNonZeroDirection;
    }
}