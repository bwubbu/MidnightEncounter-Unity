using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public ItemHolder itemHolder;

    public void AddItem(GameObject newItem)
    {
        if (itemHolder != null)
        {
            itemHolder.AddItem(newItem);
            Debug.Log("Item added: " + newItem.name);
        }
        else
        {
            Debug.LogError("ItemHolder is not assigned in the Inspector!");
        }
    }
}
