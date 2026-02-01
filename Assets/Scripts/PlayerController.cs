using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //MovementSettings
    public float speed = 10.0f;
    public float turnSpeed = 150.0f;
    public float jumpForce = 10.0f;

    //HealthSettings
    public int health = 3;
    public AudioClip hurtSound; 

    private Rigidbody rb;
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // movement codes
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed;

       
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // fall
        if (transform.position.y < -10)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); 
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Damage Taken! Remaining Health: " + health);
        if (hurtSound != null)
        {
            AudioSource.PlayClipAtPoint(hurtSound, Camera.main.transform.position, 1.0f);
        }

        GameManager gm = Object.FindFirstObjectByType<GameManager>();
        if (gm != null) gm.UpdateHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("PLAYER DIED!");

        // Save camera point
        if (Camera.main != null)
        {
            Camera.main.transform.parent = null;
        }

        GameManager gm = Object.FindFirstObjectByType<GameManager>();
        if (gm != null) gm.GameOver();

        gameObject.SetActive(false);
    }
}