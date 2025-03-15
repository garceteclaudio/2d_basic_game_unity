using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerChat : MonoBehaviour
{
    private TextMeshProUGUI frameObjectText; // Referencia al texto con el tag "FrameObject"

    void Start()
    {
        // Buscar el objeto con tag "FrameObject" y obtener su componente TextMeshProUGUI
        GameObject frameObject = GameObject.FindGameObjectWithTag("FrameObject");

        if (frameObject != null)
        {
            frameObjectText = frameObject.GetComponent<TextMeshProUGUI>();
            frameObjectText.text = ""; // Inicialmente vacío
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'FrameObject'");
        }
    }

    void Update()
    {
        // Detectar clic con el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            DetectClick();
        }
    }

    void DetectClick()
    {
        // Lanzar un rayo desde la posición del mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Si golpea algo con el tag "Enemy"
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Debug.Log("Haz hecho click sobre un enemigo");

            // Actualizar el texto y comenzar la corrutina para ocultarlo
            if (frameObjectText != null)
            {
                frameObjectText.text = "Haz hecho click sobre el enemigo";
                StartCoroutine(HideTextAfterDelay(2f)); // Espera 2 segundos antes de borrar el texto
            }
        }
    }

    // Corrutina para ocultar el texto después de un tiempo
    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (frameObjectText != null)
        {
            frameObjectText.text = ""; // Oculta el texto
        }
    }
}
