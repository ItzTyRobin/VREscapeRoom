using UnityEngine;

public class toggleChest : MonoBehaviour
{
    public Transform chestTop;
    public float speed = 2f;
    public float angle = 100f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private float t = 0f;
    private bool isOpening = false;

    void Start()
    {
        initialRotation = chestTop.localRotation;
        targetRotation = initialRotation * Quaternion.Euler(angle, 0, 0);
    }

    void Update()
    {
        if (isOpening)
        {
            t += Time.deltaTime * speed;
            t = Mathf.Clamp01(t);

            chestTop.localRotation = Quaternion.Slerp(initialRotation, targetRotation, t);
        }
    }

    public void openChest()
    {
        isOpening = true;
        t = 0f;
    }
}