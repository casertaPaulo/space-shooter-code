using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] float fireRate = 0.5f; // Tempo entre os tiros
    [SerializeField] private Transform shotPosition;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootPeriodically()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ShootPeriodically()
    {
        while (true) // Loop infinito para atirar continuamente
        {
            Instantiate(shot, shotPosition.position, transform.rotation); // Atira na posição da nave
            yield return new WaitForSeconds(fireRate); // Espera o tempo especificado antes de atirar novamente
        }
    }
}
