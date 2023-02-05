using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Animator animator;
    public SoundManager soundManager;
    public MusicManager musicManager;

    public float speed;
    private Vector2 currSpeed;
    public float minSpeed;
    public float maxSpeed;
    public float rebound;
    public bool finish;
    public bool flight;
    public int detailsCounter;
    public float flightYPos;
    public float winScreenYPos;
    public bool endGame;
    public bool winMusic;

    void Start()
    {
        musicManager.GameMusic();
    }

    void Update()
    {
        if (!finish)
            Move();
        else if (!endGame)
            musicManager.UpdateVolume();
        Fly();
        Win();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x < 0)
            currSpeed = new Vector2(maxSpeed, maxSpeed);
        else
            currSpeed = new Vector2(speed, maxSpeed);
        Vector2 direction = new Vector2(x, y);
        
        Vector2 pos = transform.position;
        pos += direction * currSpeed * Time.deltaTime;
        pos = CheckPosition(pos);

        if (speed == 0.0f)
            GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0);

        transform.position = pos;
    }

    Vector2 CheckPosition(Vector2 pos)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x -= 0.7f;
        min.x += 0.7f;
        
        max.y -= 0.7f;
        min.y += 0.7f;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        return pos;
    }

    void Fly()
    {
        if ((finish) && (detailsCounter == 3) && (transform.position.y < flightYPos))
        {
            animator.SetBool("Fly", true);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0.5f, 7f, 0f);
            flight = true;
        }
        else if ((finish) && (detailsCounter != 3) && (transform.position.y < flightYPos - 10))
        {
            string message = "Not enough parts. You crashed!";
            FindObjectOfType<GameController>().GameOver(message);
            endGame = true;
        }
    }

    void Win()
    {
        if ((flight) && (transform.position.y > winScreenYPos - 15))
        {
            if (!winMusic)
            {
                musicManager.VictoryMusic();
                winMusic = true;
            }
            endGame = true;
        }
        if ((flight) && (transform.position.y > winScreenYPos))
        {
            string message = "You broke away from the City!";
            FindObjectOfType<GameController>().Victory(message);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            soundManager.Hit();
            Vector2 pos = transform.position;
            Vector2 rebound_dir = new Vector2(rebound, 0);
            pos += rebound_dir;
            transform.position = pos;
            speed -= 0.5f;
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        }

        if (other.tag == "JetPack")
        {
            soundManager.GetItem();
            detailsCounter += 1;
            DetailsCounter.instance.AddPoint();
        }

        if (other.tag == "House")
        {
            soundManager.Fall();
            musicManager.GameOverMusic();
            string message = "The city got you!";
            FindObjectOfType<GameController>().GameOver(message);
            Destroy(gameObject);
        }

        if (other.tag == "Finish")
        {
            finish = true;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0.5f, -7f, 0f);
            animator.SetBool("Finish", finish);
        }
    }
}
