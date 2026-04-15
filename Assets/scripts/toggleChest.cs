using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class toggleChest : MonoBehaviour
{

    public Transform chestTop;
    public bool open = false;
    public float speed = 1f;
    public float angle = 45f;
    private Quaternion targetRotation;
    private Quaternion initialRotation;
    private float openAmt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRotation = chestTop.rotation;
        initialRotation = chestTop.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            targetRotation = initialRotation * Quaternion.Euler(-angle, 0, 0);
            openAmt += Time.deltaTime * speed;
            openAmt = Mathf.Clamp(openAmt, 0, 1);
        }
        else
            targetRotation = initialRotation;

        chestTop.rotation = Quaternion.Slerp(chestTop.rotation, targetRotation, openAmt);
    }
}
