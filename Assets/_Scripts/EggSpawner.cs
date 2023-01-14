using UnityEngine;
using Random = System.Random;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    
    private _Level _level;
    private readonly Random _random = new Random();
    private int _randInt;

    void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<_Level>();
        
        InvokeRepeating(nameof(ObjectsSpawner), _level.spawnRate, _level.spawnRate);
    }
    
    // Каждую секунду спавнит яйцо в рандомном углу, если игра началась
    private void ObjectsSpawner()
    {
        if (!_level.IsGameStart) return;

        _randInt = _random.Next(1, 5);

        switch (_randInt)
        {
            case 1:
                SpawnObject(8.5f, 4.2f); break;
            case 2:
                SpawnObject(8.5f, 0.2f); break;
            case 3:
                SpawnObject(-8.5f, 4.2f); break;
            case 4:
                SpawnObject(-8.5f, 0.2f); break;
        }
    }
    
    // Спавнит яйцо в нужной точке
    private void SpawnObject(float x, float y)
    {
        Instantiate(eggPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
    }
}
