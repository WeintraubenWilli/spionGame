using UnityEngine;
using UnityEngine.UI;

public class testscript : MonoBehaviour
{
    // Referenz auf das Text-Objekt
    public Text myText;
    

    void Start()
    {
        
    }

    // Methode zum �ndern des Texts
    public void ChangeText(string newText)
    {
        // �berpr�fe, ob das Text-Objekt existiert
        if (myText != null)
        {
            // �ndere den Text des Text-Objekts
            myText.text = newText;
        }
        else
        {
            // Gib eine Warnung aus, wenn das Text-Objekt nicht gefunden wird
            Debug.LogWarning("Text-Objekt nicht gefunden!");
        }
    }
}

