using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform[] box;
    [SerializeField] private int boxCount = 35;

    private Vector2 mapSize = new Vector2(50, 50);

    private void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {        
        for (int i = 0; i < boxCount; i++)
        {
            Instantiate(box[Random.Range(0,box.Length)], new Vector2(Random.Range(0, mapSize.x), Random.Range(0, mapSize.y)), Quaternion.identity);
        }
    }
}
