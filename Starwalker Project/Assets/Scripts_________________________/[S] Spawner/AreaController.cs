using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    [Header("Арена")]
    public GameObject[] area;

    [Header("Время спавна до следущей арены")]
    [Tooltip("0 - Время не ограниченно")]
    [Range(1, 10)]
    public float spawnTime = 5;

    private int chapter;

    public GameObject Spawn()
    {
        GameObject curentArea = Instantiate(area[GetComponentInParent<SpawnerController>().chapter - 1], transform.position, Quaternion.identity);
        if (spawnTime>0)
            Destroy(curentArea, spawnTime);
        return curentArea;
    }


}
