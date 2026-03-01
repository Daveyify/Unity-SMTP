using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject cubes;
    public GameObject spheres;
    public Transform player;
    public float spawnInterval = 2f;
    public float minSpawnRadius = 3f;
    public float maxSpawnRadius = 8f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    private void SpawnObject()
    {
        Vector3 cubePosition = GetRandomPositionNearPlayer();
        Vector3 spherePosition = GetRandomPositionNearPlayer();

        Instantiate(cubes, cubePosition, Quaternion.identity);
        Instantiate(spheres, spherePosition, Quaternion.identity);
    }

    private Vector3 GetRandomPositionNearPlayer()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized;
        float distance = Random.Range(minSpawnRadius, maxSpawnRadius);

        Vector3 spawnPos = new Vector3(
            player.position.x + randomCircle.x * distance,
            player.position.y,
            player.position.z + randomCircle.y * distance
        );

        return spawnPos;
    }
}