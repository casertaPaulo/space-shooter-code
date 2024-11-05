using UnityEngine;

public class ShootingEnemy2 : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;
    [SerializeField] private GameObject impact;

    void Start()
    {
        // Pegando o Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    void Update()
    {
       
    }

    public void SetDirectionAndSpeed(Vector2 dir, float spd)
    {
        direction = dir;
        speed = spd;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            collider2D.GetComponent<PlayerController>().loseLife(1);
        }
        Destroy(gameObject);
        Instantiate(impact, transform.position, transform.rotation);
    }
}
