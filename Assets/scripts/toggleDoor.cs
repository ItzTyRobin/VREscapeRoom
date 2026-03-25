using UnityEngine;

public class toggleDoor : MonoBehaviour
{

    public Transform door;
    public float angle = 90f;
    public bool isOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        float openangle = isOpen ? angle : -angle;

        door.RotateAround(transform.position, transform.up, openangle);
    }
}
