using UnityEngine;

public class PadLockEmissionColor : MonoBehaviour
{
    public Color glowColor = Color.yellow;
    public float blinkSpeed = 2f;

    private Renderer rend;
    private Material mat;
    private bool isSelected = false;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        mat.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        if (isSelected)
        {
            Color finalColor = Color.Lerp(Color.clear, glowColor, Mathf.PingPong(Time.time * blinkSpeed, 1f));
            mat.SetColor("_EmissionColor", finalColor);
        }
        else
        {
            mat.SetColor("_EmissionColor", Color.clear);
        }
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }
}