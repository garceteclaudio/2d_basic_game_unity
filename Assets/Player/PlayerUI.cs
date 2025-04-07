using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI nameText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateExperienceUI(int currentExp, int maxExp)
    {
        if (experienceText != null)
            experienceText.text = $"{currentExp}/{maxExp}";
    }

    private void Update()
    {
        if (nameText != null)
            nameText.transform.position = transform.position - new Vector3(0, 1.5f, 0);
    }
}