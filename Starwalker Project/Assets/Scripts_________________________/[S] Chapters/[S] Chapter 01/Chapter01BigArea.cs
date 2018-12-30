using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter01BigArea : MonoBehaviour
{
    private float point;
    private const float stepX = 100f;
    private const float areaSizeY = 540f;

    [Header("Препятствия")]
    public GameObject[] obstruction;
    [Header("Ловушки")]
    public GameObject[] trap;
    [Header("Солдаты")]
    public GameObject[] solder;
    [Header("Специалисты")]
    public GameObject[] special;

    private int rnd;

    void Awake()
    {
        point = GetComponent<Transform>().transform.position.x + stepX;
        rnd = Random.Range(0, 2);
    }
    void Start()
    {
        if (rnd == 0)
        {

            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, -areaSizeY / 2f), Quaternion.identity);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, 0f), Quaternion.identity);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, areaSizeY / 2f), Quaternion.identity);
        }
        //___________________________________________________________________________________________________________________________________
        else if (rnd == 1)
        {
            float y = Random.Range(-areaSizeY + 150, areaSizeY - 150f);
            Instantiate(obstruction[Random.Range(0, obstruction.Length)], new Vector2(point, y + 100), Quaternion.identity);
            Instantiate(obstruction[Random.Range(0, obstruction.Length)], new Vector2(point, y - 100), Quaternion.identity);

            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point + 125, Random.Range(-areaSizeY + 100, areaSizeY - 100)), Quaternion.identity);
        }
    }
}
