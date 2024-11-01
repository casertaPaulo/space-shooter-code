using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 10.0f; 
    [SerializeField] int life = 3;
    [SerializeField] GameObject explosion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 tilt = Input.acceleration;
        Vector3 movement = new Vector3(tilt.x, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        Vector2 myspeed = new Vector2(horizontal * speed, 0f);
        rb.velocity = myspeed;
    }

    public void loseLife(int damage){
        life -= damage;

        if(life <= 0){
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
