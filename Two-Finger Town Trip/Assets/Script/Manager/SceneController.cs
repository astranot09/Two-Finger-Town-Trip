using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void MainMenuScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void GameScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameplayScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
