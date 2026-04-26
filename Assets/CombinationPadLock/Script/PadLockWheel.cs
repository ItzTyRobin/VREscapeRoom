using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PadLockWheel : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
{
    public int wheelIndex;
    public PadLockPassword passwordManager;
    public PadLockEmissionColor emissionColor;

    public float stepAngle = 36f;
    public float inputCooldown = 0.25f;

    private int currentDigit = 0;
    private float nextInputTime = 0f;

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        if (emissionColor != null) emissionColor.SetSelected(true);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if (!isSelected && emissionColor != null) emissionColor.SetSelected(false);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (emissionColor != null) emissionColor.SetSelected(true);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (emissionColor != null) emissionColor.SetSelected(false);
    }

    private void Update()
    {
        if (!isSelected) return;
        if (Time.time < nextInputTime) return;

        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axis))
        {
            if (axis.y > 0.7f)
            {
                StepUp();
                nextInputTime = Time.time + inputCooldown;
            }
            else if (axis.y < -0.7f)
            {
                StepDown();
                nextInputTime = Time.time + inputCooldown;
            }
        }
    }

    public void StepUp()
    {
        currentDigit = (currentDigit + 1) % 10;
        transform.Rotate(-stepAngle, 0, 0, Space.Self);
        passwordManager.SetDigit(wheelIndex, currentDigit);
    }

    public void StepDown()
    {
        currentDigit = (currentDigit + 9) % 10;
        transform.Rotate(stepAngle, 0, 0, Space.Self);
        passwordManager.SetDigit(wheelIndex, currentDigit);
    }
}