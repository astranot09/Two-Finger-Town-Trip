using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject pausePanel;
    public void MainMenuScene()
    {
        SceneController.instance.MainMenuScene();
    }
    public void StartGame()
    {
        SceneController.instance.GameScene();
    }

    public void Setting()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }
    public void Credit()
    {
        creditPanel.SetActive(!creditPanel.activeSelf);
    }

    public void Paused()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);

        if (pausePanel.activeSelf)
        {
            // Correct way to lock the cursor in Unity
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; // Optional: Makes sure they can see the mouse to click menu buttons
            Time.timeScale = 0f;

        }
        else
        {
            // Correct way to unlock the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; // Optional: Hides the mouse again for gameplay
            Time.timeScale = 1f;
        }
    }

    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }


    public void PausedInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Paused();
        }
    }

}
