using UnityEngine;

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
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }
}
