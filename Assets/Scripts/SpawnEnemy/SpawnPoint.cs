using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array de prefabs de inimigos
    [SerializeField] private float initialSpawnInterval = 2f; // Intervalo de spawn inicial
    [SerializeField] private int initialEnemiesPerWave = 5; // Número inicial de inimigos por horda
    [SerializeField] private float waveInterval = 5f; // Intervalo entre hordas

    private int currentWave = 1; // Número da horda atual
    private bool spawning = false; // Controla se estamos no meio de uma horda
    [SerializeField] private float sideAdjustmentFactor = 0.1f; // Fator de ajuste para as laterais

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (true)
        {
            if (!spawning)
            {
                spawning = true;
                int enemiesToSpawn = initialEnemiesPerWave + currentWave; // Aumenta o número de inimigos a cada horda
                float spawnInterval = Mathf.Max(0.5f, initialSpawnInterval - currentWave * 0.1f); // Diminui o intervalo com o tempo

                for (int i = 0; i < enemiesToSpawn; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(spawnInterval); // Espera entre cada inimigo
                }

                currentWave++; // Passa para a próxima horda
                spawning = false;
            }

            // Espera o intervalo entre hordas
            yield return new WaitForSeconds(waveInterval);
        }
    }

    private void SpawnEnemy()
    {
        // Escolhe aleatoriamente um tipo de inimigo
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Calcula a área de spawn baseada na câmera
        Camera camera = Camera.main;
        float screenHeightInWorldUnits = 2f * camera.orthographicSize;
        float screenWidthInWorldUnits = screenHeightInWorldUnits * camera.aspect;

        // Calcula a largura ajustada para as laterais
        float adjustedWidth = screenWidthInWorldUnits * (1 - sideAdjustmentFactor);

        // Calcula uma posição aleatória dentro da área de spawn ajustada
        Vector2 spawnPosition = new Vector2(
            Random.Range(-adjustedWidth / 2, adjustedWidth / 2),
            Random.Range(-screenHeightInWorldUnits / 2, screenHeightInWorldUnits / 2)
        );

        Vector2 finalPosition = (Vector2)transform.position + spawnPosition;

        // Instancia o inimigo na posição calculada
        Instantiate(enemyPrefab, finalPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha a área de spawn no editor para facilitar visualização
        Camera camera = Camera.main;
        float screenHeightInWorldUnits = 2f * camera.orthographicSize;
        float screenWidthInWorldUnits = screenHeightInWorldUnits * camera.aspect;

        // Calcula a largura ajustada para as laterais
        float adjustedWidth = screenWidthInWorldUnits * (1 - sideAdjustmentFactor);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(adjustedWidth, screenHeightInWorldUnits));
    }
}
