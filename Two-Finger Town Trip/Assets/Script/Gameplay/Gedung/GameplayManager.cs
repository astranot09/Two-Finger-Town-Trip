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

}
