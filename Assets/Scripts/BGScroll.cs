using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed;
    private MeshRenderer meshRenderer;
    private float xScroll;

    public Transform cliff;
    public float globalTimer;
    public bool appeared = false;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        globalTimer += Time.deltaTime; 
        if (globalTimer < 94.6f)
            Scroll();
        UpdateCliff();
    }

    void Scroll()
    {
        xScroll = globalTimer * scrollSpeed; 
        Vector2 offset = new Vector2(xScroll, 0f);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void UpdateCliff()
    {
        if ((globalTimer >= 90.0f) && (!appeared))
        {
            Instantiate(cliff, new Vector3(35.0f, 0.0f, 0.0f), cliff.rotation);
            appeared = true;
        }
    }
}
