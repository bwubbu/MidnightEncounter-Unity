using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ItemHolder : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    private int currentItemIndex = -1;
    public Text currentItemText; // Reference to the UI Text element

    void Start()
    {
        // Hide all items at the start
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
        UpdateUI();
    }

    void Update()
    {
        // Check for number key inputs (1 to 8)
        for (int i = 0; i < 8; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SetActiveItem(i);
                break;
            }
        }
    }

    public void AddItem(GameObject newItem)
    {
        items.Add(newItem);
        SetActiveItem(items.Count - 1);
    }

    public bool HasItem(string itemName)
    {
        foreach (GameObject item in items)
        {
            if (item.name == itemName)
            {
                return true;
            }
        }
        return false;
    }

    PickUp pickUp = new PickUp();
    public bool GetItem(String itemName)
    {
        return pickUp.PickedItem(itemName);
    }

    public void SetActiveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            if (currentItemIndex >= 0 && currentItemIndex < items.Count)
            {
                items[currentItemIndex].SetActive(false);
            }
            currentItemIndex = index;
            items[currentItemIndex].SetActive(true);
            UpdateUI();
        }
        else
        {
            Debug.LogWarning("Invalid item index: " + index);
        }
    }

    public void SwitchToNextItem()
    {
        if (items.Count == 0) return;

        int nextIndex = (currentItemIndex + 1) % items.Count;
        SetActiveItem(nextIndex);
    }

    public void SwitchToPreviousItem()
    {
        if (items.Count == 0) return;

        int previousIndex = (currentItemIndex - 1 + items.Count) % items.Count;
        SetActiveItem(previousIndex);
    }

    private void UpdateUI()
    {
        if (currentItemText != null)
        {
            if (currentItemIndex >= 0 && currentItemIndex < items.Count)
            {
                currentItemText.text = "Current Item: " + items[currentItemIndex].name;
            }
            else
            {
                currentItemText.text = "No Item Selected";
            }
        }
    }
}
