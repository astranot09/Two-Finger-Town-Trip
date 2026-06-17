using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject creditPanel;

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


    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }
}
