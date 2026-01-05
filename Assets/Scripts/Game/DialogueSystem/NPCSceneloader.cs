using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCDialogueSceneLoader : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    private bool hasLoaded = false;

    void OnEnable()
    {
        DialogueManager.OnDialogueEnded += LoadScene;
    }

    void OnDisable()
    {
        DialogueManager.OnDialogueEnded -= LoadScene;
    }

    void LoadScene()
    {
        if (hasLoaded) return;

        hasLoaded = true;
        SceneManager.LoadScene(nextSceneName);
    }
}
