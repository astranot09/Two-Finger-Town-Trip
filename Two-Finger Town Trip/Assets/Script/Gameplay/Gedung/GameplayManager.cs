using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Obstacle Setting")]
    [SerializeField] private float obstacleSpeed = 5f;
    [SerializeField] private int obstacleType = 1;
    public float ObstacleSpeed => obstacleSpeed + (level * levelAddSpeed);
    public int ObstacleType => obstacleType;


    [Header("Score Setting")]
    [SerializeField] private int score;
    [SerializeField] private int scorePluss = 10;
    [SerializeField] private float scoreTime = 1f;
    [SerializeField] private float currScoreTime = 0;


    [Header("Level Setting")]
    [SerializeField] private int level;
    [SerializeField] private float levelAddSpeed = 0.3f;
    [SerializeField] private float levelGapTime = 10f;
    [SerializeField] private float currlevelGapTime = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;

            if (UIManager.instance != null)
            {
                UIManager.instance.UpdateScore();
            }
        }
    }


    [Header("Timer")]
    [SerializeField] private float timerType = 10f;
    [SerializeField] private float currTimerType = 0;

    private void Start()
    {
        currScoreTime = scoreTime;
        currlevelGapTime = levelGapTime;
        currTimerType = timerType;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {

        ChangeTypeTimer(Time.deltaTime);
        AddScoreTimer(Time.deltaTime);
        AddLevelTimer(Time.deltaTime);
    }


    private void ChangeTypeTimer(float deltaTime)
    {
        currTimerType -= deltaTime;

        if (currTimerType <= 0)
        {
            currTimerType = timerType;
            switch (obstacleType)
            {
                case 1:
                    Debug.Log("Ganti");
                    //obstacleType = 2; 
                    break;
                    //case 2:
                    //    obstacleType = 1; break;
            }
        }
    }

    private void AddScoreTimer(float deltaTime)
    {
        currScoreTime -= deltaTime;
        if (currScoreTime <= 0)
        {
            currScoreTime = scoreTime;
            AddScore(scorePluss);

        }
    }

    public void AddScore(int x)
    {
        Score += x;
    }

    private void AddLevelTimer(float deltaTime)
    {
        currlevelGapTime -= deltaTime;

        if (currlevelGapTime <= 0)
        {
            currlevelGapTime = levelGapTime;
            UIManager.instance.SpeedUp();
            level++;
        }
    }


}
