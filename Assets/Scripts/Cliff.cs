using UnityEngine;

public class Cliff : MonoBehaviour
{
    public float movementTimer;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-7, 0, 0);
    }

    void Update()
    {
        movementTimer += Time.deltaTime;
        StopMovement();
    }

    void StopMovement()
    {
        if (movementTimer >= 4.6f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }        
    }
}
