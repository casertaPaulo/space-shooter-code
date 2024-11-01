using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // Prefab do inimigo
    [SerializeField] private float spawnInterval = 2f; // Intervalo entre spawns
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(10f, 5f); // Tamanho da área de spawn

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Calcula uma posição aleatória dentro da área de spawn
        Vector2 spawnPosition = new Vector2(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
        );

        // Ajusta a posição de spawn com base na posição do spawner
        Vector2 finalPosition = (Vector2)transform.position + spawnPosition;

        // Instancia o inimigo na posição calculada
        Instantiate(enemyPrefab, finalPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha a área de spawn no editor para facilitar visualização
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
