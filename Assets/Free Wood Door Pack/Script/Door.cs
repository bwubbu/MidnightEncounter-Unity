using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorScript
{
    [RequireComponent(typeof(AudioSource))]
    public class Door : MonoBehaviour
    {
        public bool open;
        public float smooth = 1.0f;
        float DoorOpenAngle = -90.0f;
        float DoorCloseAngle = 0.0f;
        public AudioSource asource;
        public AudioClip openDoor, closeDoor, lockSound, unlockSound;
        public GameObject InteractText;
        public bool isLocked = true;  // Set to true by default, so door starts locked
        public string keyName = "Key"; // Name of the key item

        private PlayerInventory playerInventory;

        void Start()
        {
            asource = GetComponent<AudioSource>();
            playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        }

        void Update()
        {
            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);
            }
            else
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);
            }
        }

        public void OpenDoor()
        {
            if (!isLocked)
            {
                open = !open;
                asource.clip = open ? openDoor : closeDoor;
                asource.Play();
            }
            else
            {
                Debug.Log("Door is locked");
                if (lockSound != null)
                {
                    asource.clip = lockSound;
                    asource.Play();
                }
            }
        }

		bool openedLocked = false;

        public bool TryUnlockDoor()
        {
            if (playerInventory.itemHolder.HasItem(keyName))
            {
                isLocked = false;
                asource.clip = unlockSound;
                asource.Play();
                Debug.Log("Door unlocked with " + keyName);
				openedLocked = true;
                return false; // Successfully unlocked the door
            }
            else
            {
                Debug.Log("Player does not have the " + keyName);
                if (lockSound != null)
                {
                    asource.clip = lockSound;
                    asource.Play();
                }
                return true; // Failed to unlock the door
            }
        }

		public bool CheckIfOpen()
		{
			return openedLocked;
		}
    }
}
