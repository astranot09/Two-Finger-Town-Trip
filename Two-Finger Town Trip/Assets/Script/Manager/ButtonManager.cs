using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    public void StartGame()
    {
        SceneController.instance.GameScene();
    }

    public void Setting()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }
}
