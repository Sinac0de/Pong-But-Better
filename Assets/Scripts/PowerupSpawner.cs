using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] powerUpPrefabArray;
    [SerializeField] private float spawnInterval = 8f;

    private void Start() {
        InvokeRepeating(nameof(Spawn), 5f, spawnInterval);
    }

    private void Spawn() {
        int randomIndex = Random.Range(0, powerUpPrefabArray.Length);

        Vector2 spawnPos = new Vector2(0, Random.Range(-3f, 3f));

        Instantiate(powerUpPrefabArray[randomIndex], spawnPos, Quaternion.identity);
    }
}
