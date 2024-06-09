using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public TMP_InputField displayText;
    public string correctCode = "1234";

    public void HandleButtonPress(string value)
    {
        if (value == "clear")
        {
            displayText.text = "";
        }
        else if (value == "enter")
        {
            if (displayText.text == correctCode)
            {
                Debug.Log("Correct code entered");
            }
            else
            {
                Debug.Log("Incorrect code entered");
            }
        }
        else
        {
            displayText.text += value;
        }
    }
}