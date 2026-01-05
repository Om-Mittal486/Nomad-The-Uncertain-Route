using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string playerTag = "Player";

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag(playerTag))
        {
            triggered = true;
            SceneManager.LoadScene(sceneName);
        }
    }
}
