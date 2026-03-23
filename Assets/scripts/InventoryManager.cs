using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public bool hasKey = false;

    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key Collected!");
    }
}
