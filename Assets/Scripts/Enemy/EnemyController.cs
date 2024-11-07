using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] private int life = 1;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private float powerUpChance = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, speed);
    }

    void Update()
    {
        
    }

    //Método para perder vida
    public void loseLife(int damage){
        life -= damage;

        if(life <= 0){
            //Quando morrer adicionar pontuação para o player
            ScoreController.instance.addScore(5);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Destroyer")){
            Destroy(gameObject);
        }
        if(collider2D.CompareTag("Player")){
            loseLife(10);
        }
        if(collider2D.CompareTag("ShotPlayer")){
            powerUpSpawn();
        }
    }

    private void powerUpSpawn(){
        float randomValue = Random.Range(0f ,1f);
        Debug.Log(randomValue);
        if(randomValue <= powerUpChance){
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }
}
