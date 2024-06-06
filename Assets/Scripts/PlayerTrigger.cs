using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";

    [SerializeField]
    private UnityEvent onPlayerEnter;

    [SerializeField]
    private UnityEvent onPlayerExit;

    private int colliderCount;

    private void Awake()
    {
        var triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            if(IsPlayerExited())
            {
                onPlayerEnter.Invoke();
            }

            colliderCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsPlayer(other) && !IsPlayerExited())
        {
            colliderCount--;

            if (IsPlayerExited())
            {
                onPlayerExit.Invoke();
            }
        }
    }

    private bool IsPlayerExited()
    {
        return colliderCount <= 0;
    }

    private bool IsPlayer(Component component)
    {
        return component.gameObject.CompareTag(playerTag);
    }
}
