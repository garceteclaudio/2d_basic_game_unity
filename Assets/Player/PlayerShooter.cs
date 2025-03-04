using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform firePoint;      // Punto de origen del disparo
    public float bulletSpeed = 10f;  // Velocidad de la bala
    public float bulletLifetime = 2f; // Tiempo de vida de la bala antes de ser destruida

    void Update()
    {
        // Detectar si se presiona la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en el punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtener el componente Rigidbody2D de la bala y aplicar velocidad
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody2D.");
        }

        // Destruir la bala después de un tiempo para evitar que sigan existiendo indefinidamente
        Destroy(bullet, bulletLifetime);
    }
}