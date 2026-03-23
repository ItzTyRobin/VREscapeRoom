using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InventoryManager playerInventory = other.GetComponent<InventoryManager>();

        if (playerInventory != null )
        {
            playerInventory.CollectKey();
            Debug.Log("Key Collected!");
        }
    }
}
