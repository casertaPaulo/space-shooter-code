
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
     [SerializeField] private GameObject impact;

    void Start()
    {
        // Pegando o Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, speed);
    }
    void Update()
    {
       
    }

     private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player")){
            collider2D.GetComponent<PlayerController>().loseLife(1);
        }
        Destroy(gameObject);
        Instantiate(impact, transform.position, transform.rotation);
    }
}
