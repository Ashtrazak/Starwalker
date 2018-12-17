using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter01ShortArea : MonoBehaviour
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

    void Awake ()
    {
        point = GetComponent<Transform>().transform.position.x + stepX;
        rnd = Random.Range(0, 3);
    }
    void Start()
    {
        if (rnd == 0)
        {

            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, -areaSizeY/2f), Quaternion.identity);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, 0f), Quaternion.identity);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, areaSizeY/2f), Quaternion.identity);
        }
        //___________________________________________________________________________________________________________________________________
        else if (rnd == 1)
        {
            float y = Random.Range(-areaSizeY + 150, areaSizeY - 150f);
            Instantiate(obstruction[Random.Range(0, obstruction.Length)], new Vector2(point, y+100), Quaternion.identity);
            Instantiate(obstruction[Random.Range(0, obstruction.Length)], new Vector2(point, y-100), Quaternion.identity);

            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point + 125, Random.Range(-areaSizeY+100, areaSizeY-100)), Quaternion.identity);
        }
        //___________________________________________________________________________________________________________________________________
        else if (rnd == 2)
        {
            float y = Random.Range(0, areaSizeY - 100f);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point, y), Quaternion.identity);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point + 75f, y - 150), Quaternion.identity);
            Instantiate(solder[Random.Range(0, solder.Length)], new Vector2(point + 150f, y - 300), Quaternion.identity);
        }
        //___________________________________________________________________________________________________________________________________
        else if (rnd == 3)
        {

        }
        //___________________________________________________________________________________________________________________________________
        else if (rnd == 4)
        {

        }
        //___________________________________________________________________________________________________________________________________
        else if (rnd == 4)
        {

        }
        //___________________________________________________________________________________________________________________________________

    }
}
