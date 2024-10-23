using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int enemyIncreasePerWave;
    [SerializeField] private int numeberOfStartingEnemies;
    private int numerOfEnemies;
    private float time;

    private void Start()
    {
        time = 0;
        numerOfEnemies = numeberOfStartingEnemies;
    }

    void FixedUpdate()
    {
        if (time > timeBetweenWaves) 
        {
            for(int j = 0; j < numerOfEnemies; j++)
            {
                Vector3 spawnLocation = new();
                if (Random.value > 0.5f)
                {
                    spawnLocation.x = Random.Range(30f, 50f);
                }
                else
                {
                    spawnLocation.x = -Random.Range(30f, 50f);
                }
                if (Random.value > 0.5f)
                {
                    spawnLocation.z = Random.Range(30f, 50f);
                }
                else
                {
                    spawnLocation.z = -Random.Range(30f, 50f);
                }
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position 
                    + spawnLocation, enemyPrefab.transform.rotation);
                newEnemy.name = "Enemy";
            }
            time = 0;
            numerOfEnemies += enemyIncreasePerWave;
        }
        time += Time.fixedDeltaTime;
    }
}
