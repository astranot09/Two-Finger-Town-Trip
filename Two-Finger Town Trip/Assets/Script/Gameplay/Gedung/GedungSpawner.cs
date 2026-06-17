using System.Collections.Generic;
using UnityEngine;

public class GedungSpawner : MonoBehaviour
{
    public static GedungSpawner instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private List<GameObject> obstaclePrefabType1 = new();
    [SerializeField] private List<GameObject> obstaclePrefabType2 = new();



    private void Start()
    {
        SpawningObstacle();
    }

    public void SpawningObstacle()
    {
        int type = GameplayManager.instance.ObstacleType;
        if (type == 1)
        {
            RandomizeSpawn(obstaclePrefabType1);
        }
        else if(type == 2)
        {
            RandomizeSpawn(obstaclePrefabType2);
        }
    }

    public void RandomizeSpawn(List<GameObject> obstacles)
    {
        int x = RandomizeIndex(obstacles.Count);
        Instantiate(obstacles[x], this.transform.position, Quaternion.identity);
    }


    public int RandomizeIndex(int totalIndex)
    {
        int index = Random.Range(0, totalIndex);
        return index;
    }
}
