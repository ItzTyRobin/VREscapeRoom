using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string keyID = string.Empty;

    public string KeyID => string.IsNullOrWhiteSpace(keyID) ? gameObject.name : keyID;

    private void OnTriggerEnter(Collider other)
    {
        InventoryManager playerInventory = other.GetComponent<InventoryManager>();

        if (playerInventory != null)
        {
            playerInventory.CollectKey();
            Debug.Log("Key Collected!");
        }
    }

    public bool Matches(string requiredKeyID)
    {
        return Normalize(KeyID) == Normalize(requiredKeyID);
    }

    private static string Normalize(string value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : value.Trim().ToLowerInvariant().Replace(" ", string.Empty);
    }
}
