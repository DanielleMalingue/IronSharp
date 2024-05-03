using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputter : MonoBehaviour
{
    public TMP_Text tmpText; // Reference to the TextMeshPro Text component
    public TMP_InputField inputField; // Reference to the UI InputField

    public void SendMessage()
    {
        string message = inputField.text; // Get the text from the InputField
        tmpText.text = message; // Set the TextMeshPro Text component text to the input text
    }
}
