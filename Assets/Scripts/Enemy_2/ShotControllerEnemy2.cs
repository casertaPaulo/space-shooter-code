using System.Collections;
using UnityEngine;

public class ShotControllerEnemy2 : MonoBehaviour
{
    [SerializeField] GameObject shot; // Prefab do tiro
    [SerializeField] float fireRateMin = 0.5f; // Intervalo mínimo entre tiros
    [SerializeField] float fireRateMax = 2f;   // Intervalo máximo entre tiros
    [SerializeField] private Transform shotPosition; // Posição do tiro
    [SerializeField] private float shotSpeed = 5f; // Velocidade do tiro

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

        while (true) // Loop contínuo para disparos periódicos
        {
            var player = FindObjectOfType<PlayerController>();
            if (player != null && GetComponent<SpriteRenderer>().isVisible) // Verifica se o inimigo está visível
            {
                var myShot = Instantiate(shot, shotPosition.position, Quaternion.identity); // Atira na posição do inimigo
                Vector2 direction = (player.transform.position - myShot.transform.position).normalized;

                var rb = myShot.GetComponent<Rigidbody2D>();
                myShot.GetComponent<ShootingEnemy2>().SetDirectionAndSpeed(direction, shotSpeed);

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                myShot.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
            }  

            // Define um novo intervalo de tiro aleatório para o próximo tiro
            float fireRate = Random.Range(fireRateMin, fireRateMax);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
