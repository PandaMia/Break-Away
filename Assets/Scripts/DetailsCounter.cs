using UnityEngine;
using TMPro;

public class DetailsCounter : MonoBehaviour
{
    public static DetailsCounter instance;
    public TextMeshProUGUI detailsCounter;
    int counter = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        detailsCounter.text = "JET PACK: " + counter.ToString() + "/3"; 
    }

    public void AddPoint()
    {
        counter += 1;
        detailsCounter.text = "JET PACK: " + counter.ToString() + "/3"; 
    }
}
