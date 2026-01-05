using UnityEngine;

public class TeleportTrigger2D : MonoBehaviour
{
    [SerializeField]
    private Vector3 teleportPosition =
        new Vector3(-20.2800007f, 0.180000007f, 0f);

    [SerializeField] private string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        other.transform.position = teleportPosition;

        // GUARANTEED RESET
        if (DelayedHierarchyToggle.Instance != null)
            DelayedHierarchyToggle.Instance.ResetTimer();
    }
}
