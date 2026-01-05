using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuCanvas;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip escPressSound;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        ResumeGame(); // ensure normal state on start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 🔊 Play ESC sound
            if (audioSource && escPressSound)
                audioSource.PlayOneShot(escPressSound);

            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Optional: Call this from a Quit button
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
