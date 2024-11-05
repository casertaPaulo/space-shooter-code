using System.Collections;
using UnityEngine;

public class ShotControllerEnemy : MonoBehaviour
{
    [SerializeField] GameObject shot; // Prefab do tiro
    [SerializeField] float fireRateMin = 0.5f; // Intervalo mínimo entre tiros
    [SerializeField] float fireRateMax = 2f;   // Intervalo máximo entre tiros
    [SerializeField] private Transform shotPosition; // Posição do tiro

    void Start()
    {
        // Inicia o primeiro tiro com um atraso aleatório
        float initialDelay = Random.Range(fireRateMin, fireRateMax);
        StartCoroutine(ShootPeriodically(initialDelay)); 
    }

    private IEnumerator ShootPeriodically(float initialDelay)
    {
        // Espera o tempo inicial aleatório
        yield return new WaitForSeconds(initialDelay);
        
        while (true) // Loop contínuo para disparos
        {
            // Verifica se o inimigo está visível antes de atirar
            bool isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;

            if (isVisible) 
            {
                Instantiate(shot, shotPosition.position, transform.rotation); // Atira na posição do inimigo
            }

            // Define um novo intervalo de tiro aleatório para o próximo tiro
            float fireRate = Random.Range(fireRateMin, fireRateMax);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
