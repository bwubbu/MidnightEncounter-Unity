using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Keypad keypad;
    public string ButtonValue;

    public void OnMouseDown()
    {
        keypad.HandleButtonPress(ButtonValue);
    }
}
