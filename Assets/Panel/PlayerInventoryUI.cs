using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    private TextMeshProUGUI playerNameText; // Referencia al texto con el tag "FrameObject"

    void Start()
    {
        // Buscar el objeto con tag "FrameObject" y obtener su componente TextMeshProUGUI
        GameObject frameObject = GameObject.FindGameObjectWithTag("PlayerName");

        if (frameObject != null)
        {
            playerNameText = frameObject.GetComponent<TextMeshProUGUI>();
            playerNameText.text = PlayerPrefs.GetString("UserInput", "Valor predeterminado"); ; // Inicialmente vacío
        }
        else
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'FrameObject'");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
