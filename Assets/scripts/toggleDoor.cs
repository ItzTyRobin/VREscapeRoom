using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class toggleDoor : MonoBehaviour
{
    public Transform door;
    public bool isOpen = false;
    public float speed = 2f;
    public float angle = 45f;
    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = door.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;

            if (isOpen)
                targetRotation *= Quaternion.Euler(0, angle, 0);
            else
                targetRotation *= Quaternion.Euler(0, -angle, 0);
        }

        door.rotation = Quaternion.Slerp(door.rotation, targetRotation, Time.deltaTime * speed);
    }
}
