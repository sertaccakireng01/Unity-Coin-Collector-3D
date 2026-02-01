using UnityEngine;

public class Hazard : MonoBehaviour
{
    //MovementSettings
    public float speed = 8.0f;  
    public float range = 10.0f; 
    public bool moveOnX = false;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        if (moveOnX)
        {
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);
        }

        
        float distanceFromStart = 0;

        if (moveOnX)
            distanceFromStart = Mathf.Abs(transform.position.x - startPos.x);
        else
            distanceFromStart = Mathf.Abs(transform.position.z - startPos.z);

        
        if (distanceFromStart >= range)
        {
            direction *= -1; 
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }
}
