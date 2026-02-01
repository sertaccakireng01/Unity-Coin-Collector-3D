using UnityEngine;

public class Rotator : MonoBehaviour //coin rotator code
{
    
    public Vector3 rotateSpeed = new Vector3(0, 0, 100);

    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }
}
