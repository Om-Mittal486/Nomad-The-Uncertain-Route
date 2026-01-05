using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuCanvas;
    public GameObject controlsMenuCanvas;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip escPressSound;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        if (controlsMenuCanvas != null)
            controlsMenuCanvas.SetActive(false);

        ResumeGame(); // ensure normal state on start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 🔊 Play ESC sound
            if (audioSource && escPressSound)
                audioSource.PlayOneShot(escPressSound);

            // 🔙 If controls menu is open, close it
            if (controlsMenuCanvas != null && controlsMenuCanvas.activeSelf)
            {
                CloseControls();
                return;
            }

            // ⏸ Normal pause toggle
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        if (controlsMenuCanvas != null)
            controlsMenuCanvas.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        if (controlsMenuCanvas != null)
            controlsMenuCanvas.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // 🎮 Called by Controls button
    public void OpenControls()
    {
        pauseMenuCanvas.SetActive(false);
        if (controlsMenuCanvas != null)
            controlsMenuCanvas.SetActive(true);
    }

    // 🔙 Close Controls (ESC)
    void CloseControls()
    {
        if (controlsMenuCanvas != null)
            controlsMenuCanvas.SetActive(false);

        pauseMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
