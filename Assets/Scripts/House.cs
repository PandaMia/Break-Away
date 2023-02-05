using UnityEngine;

public class House : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<BGScroll>().globalTimer < 95.6f)
            Move();
    }

    void Move()
    {
        Vector2 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.y > 4.05)
            speed = -1 * Mathf.Abs(speed);
        else if (pos.y < 2.5)
            speed = Mathf.Abs(speed);
    }
}
