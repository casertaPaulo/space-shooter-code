using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] private int life = 1;
    [SerializeField] private GameObject explosion;

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

        life -= 1;

        if(life <= 0){
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
    }
}
