using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject missilePrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 7f;

    private void Start()
    {
        InvokeRepeating("SpawnMissile", 0f, spawnInterval);
    }

    void SpawnMissile()
    {
        Vector2 randomPosition = GetRandomPositionAroundAircraft();

        Instantiate(missilePrefab, new Vector3(randomPosition.x, randomPosition.y, 0f), Quaternion.identity);
    }
    
    Vector2 GetRandomPositionAroundAircraft()
    {
        float randomAngle = Random.Range(0f, 360f);
        
        float x = transform.position.x + spawnRadius * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float y = transform.position.y + spawnRadius * Mathf.Sin(randomAngle * Mathf.Deg2Rad);
        
        return new Vector2(x, y);
    }
}