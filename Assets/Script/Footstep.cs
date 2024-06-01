using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    public GameObject jumpstep;
    public GameObject sprint;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
        jumpstep.SetActive(false);
        sprint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("s"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("a"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("d"))
        {
            footsteps();
        }

        if(Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("s"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("a"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("d"))
        {
            StopFootsteps();
        }

        if (Input.GetKeyDown("space") && !isJumping)
        {
            StartCoroutine(JumpWithDelay());
        }
        if (Input.GetKeyUp("space"))
        {
            StopJumpsteps();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            StopFootsteps();
            sprinting();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            StopSprinting();
        }


    }

    IEnumerator JumpWithDelay()
    {
        isJumping = true;
        Jumpsteps();
        yield return new WaitForSeconds(0.5f); // Adjust delayTime as needed
        StopJumpsteps();
        isJumping = false;
    }

    

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
    void Jumpsteps()
    {
        jumpstep.SetActive(true);
    }
    void StopJumpsteps()
    {
        jumpstep.SetActive(false);
    }
    void sprinting()
    {
        sprint.SetActive(true);
    }

    void StopSprinting()
    {
        sprint.SetActive(false);
    }

}