using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] GameObject shot;
    [SerializeField] GameObject shot2;
    [SerializeField] public float fireRate = 0.5f; // Tempo entre os tiros
    [SerializeField] private Transform shotPosition;
    [SerializeField] private Transform shot2Position1;
    [SerializeField] private Transform shot2Position2;
    public AudioSource audioSource;
    private PlayerController playerController;
   
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        StartCoroutine(ShootPeriodically()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ShootPeriodically()
    {
        while(true){
            if(playerController.level < 4){
                    Instantiate(shot, shotPosition.position, transform.rotation);
                    audioSource.Play();// Atira na posição da nave
                    yield return new WaitForSeconds(fireRate); // Espera o tempo especificado antes de atirar novamente
                }
                else if(playerController.level < 6){
                   Instantiate(shot2, shot2Position1.position, transform.rotation);
                   Instantiate(shot2, shot2Position2.position, transform.rotation);
                   yield return new WaitForSeconds(fireRate);
                }else if(playerController.level >= 6){
                    Instantiate(shot2, shot2Position1.position, transform.rotation);
                    Instantiate(shot2, shotPosition.position, transform.rotation);
                    Instantiate(shot2, shot2Position2.position, transform.rotation);
                    yield return new WaitForSeconds(fireRate);
                }
            else{
                break;
            }
        }
    }
}
