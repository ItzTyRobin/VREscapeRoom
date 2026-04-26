using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PadLockPassword : MonoBehaviour
{
    public int[] currentCode = { 0, 0, 0, 0 };
    public int[] _numberPassword = { 0, 0, 0, 0 };

    public UnityEvent onCorrectPassword;

    private bool unlocked = false;

    public void SetDigit(int index, int value)
    {
        currentCode[index] = value;
        CheckPassword();
    }

    private void CheckPassword()
    {
        if (unlocked) return;

        if (currentCode.SequenceEqual(_numberPassword))
        {
            unlocked = true;
            Debug.Log("Password correct");
            onCorrectPassword?.Invoke();
        }
    }
}