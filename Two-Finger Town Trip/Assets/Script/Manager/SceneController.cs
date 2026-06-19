using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController instance;

    [SerializeField] private Animator animator;
    [SerializeField] private float transitionTime = 1f;
    public bool OnTransition = false;
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
        StartCoroutine(LoadLevel("MainMenu"));
    }
    public void GameScene()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadLevel("GameplayScene"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    IEnumerator LoadLevel(string name)
    {
        OnTransition = true;
        if (animator == null || animator.gameObject == null)
        {
            GameObject transitionObj = GameObject.FindGameObjectWithTag("Transition");
            if (transitionObj != null)
            {
                animator = transitionObj.GetComponent<Animator>();
            }
        }

        // Trigger transition if an animator was successfully found
        if (animator != null)
        {
            animator.SetTrigger("Start");
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name);
        OnTransition = false;
    }
}
