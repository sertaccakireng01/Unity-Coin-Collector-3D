using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //Settings
    public int points = 1;

    //Sound Effects
    public AudioClip coinSound; 

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {

            Debug.Log("Coin collected!");
            //update points
            GameManager gm = Object.FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.AddScore(points);
            }
            //play coin sounrd
            if (coinSound != null)
            {
                // keep sound playing after collecting
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            // delete object after collecting
            Destroy(gameObject);
        }
    }
}
