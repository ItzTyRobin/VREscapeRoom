using UnityEngine;

public class doorTrigger : MonoBehaviour
{

    public toggleDoor door;
    public string requiredKeyID = "rust_key";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponent<Key>();

        if (key == null)
        {
            key = other.GetComponentInParent<Key>();
        }

        if (key != null && key.Matches(requiredKeyID))
        {
            door.isOpen = true;
            Debug.Log("trigger door stuck");
        }
    }
}
