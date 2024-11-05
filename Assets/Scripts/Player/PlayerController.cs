using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f; 
    [SerializeField] int life = 3;
    [SerializeField] GameObject explosion;

    private Rigidbody2D rb;
    private float leftBound;
    private float rightBound;
    private float halfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calcula os limites da câmera
        CalculateCameraBounds();
        
        // Pegando metade da largura da sprite do player
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    void Update()
    {
        // Capture o movimento horizontal do teclado
        float horizontal = Input.GetAxis("Horizontal");
        // Capture a inclinação do celular
        float tilt = Input.acceleration.x;

        // Determine a direção de movimento
        float moveInput = horizontal + tilt; // Combina o controle do teclado e do tilt

        // Suavização do movimento
        moveInput = Mathf.Clamp(moveInput, -1f, 1f); // Limita a entrada entre -1 e 1

        // Define a velocidade do Rigidbody
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Limitar o movimento do player dentro dos limites da tela
        float clampedX = Mathf.Clamp(transform.position.x, leftBound + halfWidth, rightBound - halfWidth);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void CalculateCameraBounds()
    {
        Camera camera = Camera.main;

        // Calcula a altura e largura da tela em unidades do mundo
        float screenHeightInWorldUnits = 2f * camera.orthographicSize;
        float screenWidthInWorldUnits = screenHeightInWorldUnits * camera.aspect;

        // Calcula os limites da câmera
        leftBound = camera.transform.position.x - screenWidthInWorldUnits / 2;
        rightBound = camera.transform.position.x + screenWidthInWorldUnits / 2;
    }

    public void loseLife(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy"))
        {
            loseLife(1);
        }
    }
}
