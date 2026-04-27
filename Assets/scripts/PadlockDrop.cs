using UnityEngine;

public class PadlockDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public void DropLock()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.useGravity = true;
    }
}

