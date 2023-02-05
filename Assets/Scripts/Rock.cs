using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = new Vector2(-1, 0).normalized;
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
