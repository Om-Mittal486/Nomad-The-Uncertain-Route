using UnityEngine;

public class OptionsMenuEsc : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    void Update()
    {
        if (!optionsMenu.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);

            // Lock cursor again
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
