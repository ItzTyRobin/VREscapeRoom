using System;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{

    public toggleDoor door;

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

        // if other is key 
        if (other.gameObject.GetComponent<Key>() != null)
        {
            door.isOpen = true;
            Debug.Log("trigger door stuck");
        }
    }
}
