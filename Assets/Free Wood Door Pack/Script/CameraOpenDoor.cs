using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraDoorScript
{
    public class CameraOpenDoor : MonoBehaviour
    {
        public float DistanceOpen = 3;
        public GameObject text;
        public GameObject InteractText;
        private PlayerInventory playerInventory;

        public bool InteractLockedDoor = false;

        // Use this for initialization
        void Start()
        {
            InteractText.SetActive(false);
            playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        }

        // Update is called once per frame
        void Update()
        {
            bool isInteracting = CheckForInteraction();

            // Optionally, you can use the boolean for other purposes in the Update method
            if (isInteracting)
            {
                Debug.Log("Player is interacting with a door.");
            }
        }

        public bool CheckForInteraction()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
            {
                DoorScript.Door door = hit.transform.GetComponent<DoorScript.Door>();
                if (door != null)
                {
                    InteractText.SetActive(true);
                    text.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!door.isLocked)
                        {
                            door.OpenDoor();
							return false;
                        }
						if (door.isLocked)
                        {
                            bool interacted = door.TryUnlockDoor();
                            InteractLockedDoor = interacted;
                        }
                        
                    }
                }
                else
                {
                    text.SetActive(false);
                    InteractText.SetActive(false);
                }
            }
            else
            {
                text.SetActive(false);
                InteractText.SetActive(false);
            }

            return InteractLockedDoor; // Player did not interact with the door
        }

        private void OnTriggerExit(Collider other)
        {
            InteractText.SetActive(false);
        }
    }
}
