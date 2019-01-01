using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;

    [Range(0.1f, 10f)]
    public float timeBetweenSpawn; 

    [Range(1, 100)]
    public int maxStarAmountPerSpawn;

    [Range(100f, 2000f)]
    public float maxStarSpeed;

    [Range(150f, 300f)]
    public float maxStarSize;

    [Range(0.1f, 1f)]
    public float maxStarTransparent;

    [Range(0f, 100f)]
    public float timeToDestroy;


    void Start()
    {
        InvokeRepeating("Spawn", 0f, timeBetweenSpawn);
    }
    void Spawn()
    {
        int starValue = Random.Range(0, maxStarAmountPerSpawn);
        for (int i = 0; i < starValue; i++)
        {
            GameObject star = Instantiate(starPrefab, new Vector2(transform.position.x + Random.Range(-Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x), transform.position.y), Quaternion.identity);
            star.GetComponent<SimpleMove>().speed = Random.Range(99f, maxStarSpeed);
            float size = Random.Range(150f, maxStarSize);
            star.GetComponent<Transform>().localScale = new Vector2(size, size);
            star.GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, Random.Range(0f, maxStarTransparent));
            star.transform.parent = gameObject.transform;
            Destroy(star, timeToDestroy);
        }
    }


}
