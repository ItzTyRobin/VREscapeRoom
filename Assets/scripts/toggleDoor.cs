using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class toggleDoor : MonoBehaviour
{
    public Transform door;
    public bool isOpen = false;
    public float speed = 2f;
    public float angle = 45f;
    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private float openAmt;

    void Start()
    {
        targetRotation = door.rotation;
        initialRotation = door.rotation;
        Debug.Log(door.rotation);
        Debug.Log(initialRotation);
        Debug.Log(targetRotation);
        Debug.Log("at start");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;

        }

        if (isOpen)
        {
            targetRotation = initialRotation * Quaternion.Euler(0, angle, 0);
            openAmt += Time.deltaTime * speed;
            openAmt = Mathf.Clamp(openAmt, 0, 1);
        }
        else
            targetRotation = initialRotation;
        Debug.Log(door.rotation);
        Debug.Log(initialRotation);
        Debug.Log(targetRotation);
        Debug.Log("at update");
        door.rotation = Quaternion.Slerp(door.rotation, targetRotation, openAmt);
    }
}
