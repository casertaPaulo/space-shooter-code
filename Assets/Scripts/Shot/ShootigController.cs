
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collider2D){
        //Quando o tiro colidir como o inimigo
        if(collider2D.CompareTag("Enemy")){
            collider2D.GetComponent<EnemyController>().loseLife(1);
        }

        Destroy(gameObject);
        Instantiate(impact, transform.position, transform.rotation);
    }

   
}
