using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;

public class TextInputHandler : MonoBehaviour
{
    public TMP_InputField inputField; // Das Input-Feld, das du im Inspektor zuweisen musst
    public TMP_Text displayText; // Das Text-Objekt, das du im Inspektor zuweisen musst

    void Start()
    {
        // Füge der InputField OnValueChanged-Handler hinzu
        
    }

    public void UpdateDisplayText(string newText)
    {
        Debug.Log(newText);
        // Aktualisiere den Text des Text-Objekts mit dem Inhalt des Inputfelds
        displayText.text = newText;
    }
}

   