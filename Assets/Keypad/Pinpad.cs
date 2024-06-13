using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class PinPad : MonoBehaviour
{
  public TMP_InputField displayText;
  public GameObject button1;
  public GameObject button2;
  public GameObject button3;
  public GameObject button4;
  public GameObject button5;
  public GameObject button6;
  public GameObject button7;
  public GameObject button8;
  public GameObject button9;
  public GameObject button0;
  public GameObject buttonClear;
  public GameObject buttonEnter;

  public GameObject WrongPassword;
  public GameObject CorrectPassword;

  public string correctCode = "1234";
  //public DoorScript.PinpadDoor door;
  public Camera mainCamera;

  void Start()
  {
    //door = GameObject.FindWithTag("PinpadDoor").GetComponent<DoorScript.PinpadDoor>();
  
  }

  public void Button1()
  {
    displayText.text += "1";
  }

  public void Button2()
  {
    displayText.text += "2";
  }

  public void Button3()
  {
    displayText.text += "3";
  }

  public void Button4()
  {
    displayText.text += "4";
  }

  public void Button5()
  {
    displayText.text += "5";
  }

  public void Button6()
  {
    displayText.text += "6";
  }

  public void Button7()
  {
    displayText.text += "7";
  }

  public void Button8()
  {
    displayText.text += "8";
  }

  public void Button9()
  {
    displayText.text += "9";
  }

  public void Button0()
  {
    displayText.text += "0";
  }

  public void ButtonClear()
  {
    displayText.text = "";
  }

  readonly float zoomSpeed = 100f;
  private bool isZoomedOut = false;

  void Update()
  {
    if (isZoomedOut)
    {
      Vector3 newPos = mainCamera.transform.position;
      newPos.z = Mathf.MoveTowards(newPos.z, -100, Time.deltaTime * zoomSpeed);

      mainCamera.transform.position = newPos;

      if (newPos.z == -100)
      {
        isZoomedOut = false;
      }
    }
  }

  public void ButtonEnter()
  {
    if (displayText.text == correctCode)
    {
      Debug.Log("Correct code entered");
      StartCoroutine(Success());
    }
    else
    {
      Debug.Log("Incorrect code entered");
      StartCoroutine(EnableWrongPassword());
      ButtonClear();
    }
  }
  private IEnumerator EnableWrongPassword()
    {
        WrongPassword.SetActive(true);
        yield return new WaitForSeconds(1f); // Wait for 2 seconds
        WrongPassword.SetActive(false);
    }

    private IEnumerator Success()
    {
        CorrectPassword.SetActive(true);
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        SceneManager.LoadScene("Outro", LoadSceneMode.Single);
    }
}