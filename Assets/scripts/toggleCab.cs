using UnityEngine;

public class toggleCab : MonoBehaviour
{
    public Transform door;
    public bool isOpen;
    public float speed = 2f;
    public float angle = -100f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float openAmount;

    private void Awake()
    {
        if (door == null)
        {
            door = transform;
        }

        initialRotation = door.localRotation;
        targetRotation = initialRotation;
    }

    private void Update()
    {
        var desiredRotation = isOpen
            ? initialRotation * Quaternion.Euler(0f, angle, 0f)
            : initialRotation;

        openAmount = Mathf.MoveTowards(openAmount, 1f, Time.deltaTime * speed);
        targetRotation = desiredRotation;
        door.localRotation = Quaternion.Slerp(door.localRotation, targetRotation, openAmount);
    }

    public void OpenDoor()
    {
        isOpen = true;
        openAmount = 0f;
    }

    public void CloseDoor()
    {
        isOpen = false;
        openAmount = 0f;
    }
}
