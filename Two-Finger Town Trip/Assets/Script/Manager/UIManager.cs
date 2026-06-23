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

    [Header("Score Setting")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Lose Setting")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text lastScoreText;

    [Header("SpeedUp Setting")]
    [SerializeField] private GameObject speedUpPrefab;
    [SerializeField] private Transform speedUpSpawner;

    public void UpdateScore()
    {
        scoreText.text = GameplayManager.instance.Score.ToString();
    }


    public void LoseSetUp()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        lastScoreText.text = GameplayManager.instance.Score.ToString();
    }
    public void SpeedUp()
    {
        Instantiate(speedUpPrefab, speedUpSpawner.position, Quaternion.identity, speedUpSpawner);
    }
}
