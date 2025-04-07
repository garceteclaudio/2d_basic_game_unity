using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [Header("Experience Settings")]
    [SerializeField] private int maxExperience = 300;
    private int experiencePoints = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddExperience(int amount)
    {
        experiencePoints += amount;
        // Evento para notificar a la UI (mejor que acceder directamente)
        PlayerUI.Instance.UpdateExperienceUI(experiencePoints, maxExperience);
    }
}