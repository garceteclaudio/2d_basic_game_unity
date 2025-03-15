using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance; // Singleton para f�cil acceso desde EnemyHealth
    public int experiencePoints = 0; // Puntos de experiencia actuales
    public int maxExperience = 300; // M�xima experiencia para subir de nivel

    private TextMeshProUGUI experienceText; // Referencia al texto UI
    private TextMeshPro nameText; // Referencia al TextMeshPro para mostrar el nombre

    void Awake()
    {
        // Configurar Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Buscar el objeto con la etiqueta "ExperiencePoints" y obtener su TextMeshProUGUI
        GameObject expObject = GameObject.FindGameObjectWithTag("ExperiencePoints");
        if (expObject != null)
        {
            experienceText = expObject.GetComponent<TextMeshProUGUI>();
            UpdateExperienceUI(); // Mostrar el puntaje inicial en la UI
        }
        else
        {
            Debug.LogError("No se encontr� el objeto con tag 'ExperiencePoints'");
        }
    }

    void Update()
    {
        // Actualizar la posici�n del texto para que siga al jugador
        if (nameText != null)
        {
            nameText.transform.position = transform.position - new Vector3(0, 1.5f, 0); // Posicionar debajo del jugador
        }
    }

    // M�todo para aumentar la experiencia
    public void AddExperience(int amount)
    {
        experiencePoints += amount;
        UpdateExperienceUI();
    }

    // Actualizar el texto en la UI
    private void UpdateExperienceUI()
    {
        if (experienceText != null)
        {
            experienceText.text = experiencePoints + "/" + maxExperience;
        }
    }
}