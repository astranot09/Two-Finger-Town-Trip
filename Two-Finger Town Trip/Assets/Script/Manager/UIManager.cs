using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private TMP_Text scoreText;

    [Header("Lose Setting")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text lastScoreText;

    public void UpdateScore()
    {
        scoreText.text = GameplayManager.instance.Score.ToString();
    }


    public void LoseSetUp()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
        lastScoreText.text = GameplayManager.instance.Score.ToString();
    }

}
