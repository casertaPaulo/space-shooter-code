using System.Collections;
using UnityEngine;

public class ShotControllerEnemy : MonoBehaviour
{
    [SerializeField] GameObject shot; // Prefab do tiro
    [SerializeField] float fireRateMin = 0.5f; // Intervalo mínimo entre tiros
    [SerializeField] float fireRateMax = 2f;   // Intervalo máximo entre tiros
    [SerializeField] private Transform shotPosition; // Posição do tiro

    private bool isVisible;

    void Start()
    {
        // Inicia o primeiro tiro com um atraso aleatório
        float initialDelay = Random.Range(fireRateMin, fireRateMax);
        StartCoroutine(ShootPeriodically(initialDelay)); 
    }

    void Update()
    {
        // Checando se o inimigo está visível antes de atirar
        isVisible = GetComponentInChildren<SpriteRenderer>().isVisible;   
    }

    private IEnumerator ShootPeriodically(float initialDelay)
    {
        // Espera o tempo inicial aleatório
        yield return new WaitForSeconds(initialDelay);

        while (true) {
            if (isVisible) {
                Instantiate(shot, shotPosition.position, transform.rotation); // Atira na posição do inimigo
            }
            // Define um novo intervalo de tiro aleatório para o próximo tiro
            float fireRate = Random.Range(fireRateMin, fireRateMax);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
