using UnityEngine;

public class ObjectsBehaviour : MonoBehaviour
{
    public Transform rock;
    public JetPack jetpack;

    public float globalTimer;

    public float obstacleTimer;
    public float obstacleGap = 0.6f;
    public float minGap = 0.12f;
    public float speedGapDecreasing = 0.01f;
    public float prevYLoc = 0.0f;

    public float detailTimer;
    public float detailGap = 25f;
    
    void Update()
    {
        globalTimer += Time.deltaTime;
        GenerateObstacle();
        GenerateDetail();
    }

    void GenerateObstacle()
    {
        obstacleTimer += Time.deltaTime;
        
        if ((obstacleTimer > obstacleGap) && (globalTimer < 89.0f))
        {
            float yLoc = Random.Range(-9.5f, 9.5f);
            while ((yLoc <= prevYLoc + 1.5f) && (yLoc >= prevYLoc - 1.5f))
            {
                yLoc = Random.Range(-9.5f, 9.5f);
            }
            Instantiate(rock, new Vector3(19, yLoc, 0), rock.rotation);
            obstacleTimer = 0;
            prevYLoc = yLoc;
        }

        obstacleGap -= Time.deltaTime * speedGapDecreasing;
        obstacleGap = Mathf.Clamp(obstacleGap, minGap, 1.5f);
    }

    void GenerateDetail()
    {
        detailTimer += Time.deltaTime;

        if ((detailTimer > detailGap) && (globalTimer < 89.0f))
        {
            float yLoc = Random.Range(-8.0f, 8.0f);
            //jetpack.position = new Vector2(19, yLoc);
            jetpack.gameObject.SetActive(true);
            jetpack.gameObject.transform.position = new Vector2(19, yLoc);
            //Instantiate(jetpack, new Vector3(19, yLoc, 0), jetpack.rotation);
            detailTimer = 0;
        }
    }
}
