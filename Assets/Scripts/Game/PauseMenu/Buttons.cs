using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    [Header("References")]
    public PauseMenu pauseMenu;   // Drag your PauseMenu script here

    // ▶ Resume Button
    public void ResumeGame()
    {
        if (pauseMenu != null)
            pauseMenu.ResumeGame();
    }

    // 🏠 Main Menu Button
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // safety reset
        SceneManager.LoadScene("MainMenu");
    }
}
