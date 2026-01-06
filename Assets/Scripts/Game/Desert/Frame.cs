using UnityEngine;
using UnityEngine.SceneManagement;

public class FrameWindow : MonoBehaviour
{
    public Animator animator;
    public string nextSceneName;   // set in Inspector
    public float sceneDelay = 5f;  // 5 seconds

    private bool canFreeze = false;
    private bool hasFrozen = false;

    void Update()
    {
        if (canFreeze && !hasFrozen && Input.GetKeyDown(KeyCode.F))
        {
            FreezeFrame();
        }
    }

    void FreezeFrame()
    {
        hasFrozen = true;
        animator.speed = 0f; // freeze animation
        StartCoroutine(LoadSceneAfterDelay());
    }

    System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(sceneDelay);
        SceneManager.LoadScene(nextSceneName);
    }

    // Animation Events
    public void EnableFreezeWindow()
    {
        canFreeze = true;
    }

    public void DisableFreezeWindow()
    {
        canFreeze = false;
    }
}
