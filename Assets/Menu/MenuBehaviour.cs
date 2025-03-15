using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI elements como Button
using TMPro; // Necesario para trabajar con TextMeshPro
using UnityEngine.SceneManagement; // Necesario para manejar la carga de escenas

public class MenuBehaviour : MonoBehaviour
{
    private TMP_InputField inputField; // Referencia al InputField de TextMeshPro
    private string userInput; // Variable para almacenar lo que el usuario ingresa

    // Este método se llama cuando el valor del InputField cambia
    public void OnInputFieldChange()
    {
        userInput = inputField.text; // Guarda el texto ingresado en la variable userInput
        Debug.Log("Input ingresado: " + userInput); // Opcional: Muestra el input en la consola
    }

    // Este método se llama cuando se hace clic en el botón de Login
    public void OnLoginButtonClick()
    {
        if (!string.IsNullOrEmpty(userInput)) // Verifica que el input no esté vacío
        {
            Debug.Log("Cargando Escena1..."); // Opcional: Muestra un mensaje en la consola

            // Guarda el valor de userInput en PlayerPrefs
            PlayerPrefs.SetString("UserInput", userInput);
            PlayerPrefs.Save(); // Guarda los cambios

            SceneManager.LoadScene("Escena1"); // Carga la escena "Escena1"
        }
        else
        {
            Debug.Log("Por favor, ingresa un valor antes de hacer clic en Login."); // Mensaje de error si el input está vacío
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Busca el botón con el tag "LogInButton" y le asigna el método OnLoginButtonClick al evento OnClick
        GameObject loginButton = GameObject.FindGameObjectWithTag("LogInButton");
        if (loginButton != null)
        {
            Button buttonComponent = loginButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(OnLoginButtonClick);
            }
        }

        // Busca el InputField de TextMeshPro en la escena usando su tag "InputField"
        GameObject inputFieldObject = GameObject.FindGameObjectWithTag("InputField");
        if (inputFieldObject != null)
        {
            inputField = inputFieldObject.GetComponent<TMP_InputField>();
            if (inputField != null)
            {
                // Asigna el método OnInputFieldChange al evento OnValueChanged del InputField
                inputField.onValueChanged.AddListener(delegate { OnInputFieldChange(); });
            }
            else
            {
                Debug.LogError("No se encontró el componente TMP_InputField en el objeto con tag 'InputField'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró un objeto con tag 'InputField' en la escena.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // No es necesario poner nada aquí para este caso
    }
}