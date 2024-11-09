using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f; 
    [SerializeField] int life = 3;
    [SerializeField] GameObject explosion;
    [SerializeField] public int level = 1;
    private ShotController shotController;
    private Rigidbody2D rb;
    private float leftBound;
    private float rightBound;
    private float halfWidth;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        shotController = GetComponent<ShotController>();

        // Calcula os limites da câmera
        CalculateCameraBounds();
        
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    void Update()
    {
        // Capture o movimento horizontal do teclado
        float horizontal = Input.GetAxis("Horizontal");
        float tilt = Input.acceleration.x;

        // Determine a direção de movimento
        float moveInput = horizontal + tilt; 

        moveInput = Mathf.Clamp(moveInput, -1f, 1f); 
        float adjustedSpeed = speed * (1 + Mathf.Abs(tilt));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        float clampedX = Mathf.Clamp(transform.position.x, leftBound + halfWidth, rightBound - halfWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void CalculateCameraBounds()
    {
        Camera camera = Camera.main;

        // Calcula a altura e largura da tela em unidades do mundo
        float screenHeightInWorldUnits = 2f * camera.orthographicSize;
        float screenWidthInWorldUnits = screenHeightInWorldUnits * camera.aspect;

        leftBound = camera.transform.position.x - screenWidthInWorldUnits / 2;
        rightBound = camera.transform.position.x + screenWidthInWorldUnits / 2;
    }

    // Perder vida
    public void loseLife(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    // Ganha level
    public void upLevel(){
        level += 1;
        shotController.fireRate -= 0.05f;
        speed += 0.5f; 
    }

    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Perde vida quando encostar em um inimigo
        if (collider2D.CompareTag("Enemy"))
        {
            loseLife(1);
        }

        if(collider2D.CompareTag("PowerUp"))
        {
            upLevel();
            Debug.Log(level);
        }
    }
}
