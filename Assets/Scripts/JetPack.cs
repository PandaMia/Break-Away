using UnityEngine;

public class JetPack : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Sprite nextSprite;

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
        if (other.tag == "Player")
        {
            ChangeSprite();
        }
        if (other.tag != "Obstacle")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }    
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = nextSprite;
    }
}
