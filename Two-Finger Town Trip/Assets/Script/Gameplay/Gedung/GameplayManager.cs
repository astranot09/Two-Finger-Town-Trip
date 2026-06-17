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


    [SerializeField] private float obstacleSpeed = 5f;
    [SerializeField] private int obstacleType = 1;
    public float ObstacleSpeed => obstacleSpeed;
    public int ObstacleType => obstacleType;



    [SerializeField] private float timerType = 10f;
    [SerializeField] private float currTimerType = 0;

    private void FixedUpdate()
    {
        if(currTimerType <= 0)
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
        currTimerType -= Time.deltaTime;
    }

}
