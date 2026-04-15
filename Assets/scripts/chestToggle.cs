using UnityEngine;

public class chestToggle : MonoBehaviour
{

    public toggleChest chestTop;
    public GameObject chestKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider chestKey)
    {
        // if other is key 
        if (chestKey)
        {
            chestTop.open = true;
        }
    }
}
