using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;
    public float eyeOffset = 0.5f; // Distancia del "eye" al centro del jugador

    private Rigidbody2D rb;
    private Vector2 movement;
    private Transform eye;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        // Buscar el objeto "eye"
        eye = transform.Find("eye");
        if (eye == null)
        {
            Debug.LogError("No se encontr� el objeto 'eye' como hijo del jugador");
        }

        // Si no hay firePoint asignado, usar el eye como firePoint
        if (firePoint == null && eye != null)
        {
            firePoint = eye;
            Debug.LogWarning("FirePoint no asignado, usando el objeto 'eye' como punto de disparo");
        }
        else if (firePoint == null)
        {
            firePoint = transform;
            Debug.LogWarning("FirePoint no asignado, usando posici�n del jugador");
        }
    }

    void Update()
    {
        // Capturar entrada de movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        // Actualizar posicion y rotacion del "eye"
        if (movement != Vector2.zero)
        {
            UpdateEyePositionAndRotation(movement);
        }

        // Disparar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void UpdateEyePositionAndRotation(Vector2 direction)
    {
        if (eye != null)
        {
            // Calcular la nueva posicion del "eye" (ligeramente adelantado en la direccion del movimiento)
            Vector2 newPosition = (Vector2)transform.position + direction * eyeOffset;
            eye.position = newPosition;

            // Calcular rotacion
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Aplicar rotacion tanto al "eye" como al firePoint
            eye.rotation = rotation;

            // Si el firePoint no es el mismo objeto que el eye, actualizarlo tambien
            if (firePoint != eye)
            {
                firePoint.position = newPosition;
                firePoint.rotation = rotation;
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Prefab de bala no asignado");
            return;
        }

        // Instanciar bala en la posicion y rotacion del firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene Rigidbody2D");
            Destroy(bullet);
        }
    }
}