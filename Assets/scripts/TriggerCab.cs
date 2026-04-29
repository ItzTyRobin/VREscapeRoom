using UnityEngine;

public class CabinentTrigger : MonoBehaviour
{
    public toggleCab cab;
    public string requiredKeyID = "CabinentKey";
    public string cabinetObjectName = "SM_cabinet";
    public string cabinetDoorName = string.Empty;
    public bool disableAfterUse = true;

    private Collider triggerCollider;

    private void Awake()
    {
        triggerCollider = GetComponent<Collider>();

        if (triggerCollider != null)
        {
            triggerCollider.isTrigger = true;
        }

        ResolveCabDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponent<Key>();

        if (key == null)
        {
            key = other.GetComponentInParent<Key>();
        }

        if (key != null && key.Matches(requiredKeyID))
        {
            ResolveCabDoor();

            if (cab == null)
            {
                Debug.LogWarning("Cabinent trigger could not find a cabinet door to open.", this);
                return;
            }

            cab.OpenDoor();
            Debug.Log("Correct key used!");

            if (disableAfterUse && triggerCollider != null)
            {
                triggerCollider.enabled = false;
            }
        }
        else if (key != null)
        {
            Debug.Log("Wrong key");
        }
    }

    private void ResolveCabDoor()
    {
        Transform selectedDoor = null;

        if (cab != null)
        {
            selectedDoor = cab.door != null ? cab.door : cab.transform;
        }
        else
        {
            GameObject cabinetRoot = GameObject.Find(cabinetObjectName);
            if (cabinetRoot == null)
            {
                return;
            }

            selectedDoor = string.IsNullOrWhiteSpace(cabinetDoorName)
                ? FindNearestCabinetDoor(cabinetRoot.transform)
                : FindChildByName(cabinetRoot.transform, cabinetDoorName);

            if (selectedDoor == null)
            {
                return;
            }

            cab = selectedDoor.GetComponent<toggleCab>();

            if (cab == null)
            {
                cab = selectedDoor.gameObject.AddComponent<toggleCab>();
            }
        }

        cab.door = selectedDoor;
        cab.angle = selectedDoor.localPosition.x < 0f ? -100f : 100f;
    }

    private Transform FindNearestCabinetDoor(Transform cabinetRoot)
    {
        Transform nearestDoor = null;
        float nearestDistance = float.MaxValue;

        foreach (Transform child in cabinetRoot.GetComponentsInChildren<Transform>(true))
        {
            if (!child.name.ToLowerInvariant().Contains("cabinet_door"))
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, child.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestDoor = child;
            }
        }

        return nearestDoor;
    }

    private Transform FindChildByName(Transform root, string childName)
    {
        foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
        {
            if (child.name == childName)
            {
                return child;
            }
        }

        return null;
    }
}
