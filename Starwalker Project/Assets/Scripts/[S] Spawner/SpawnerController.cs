using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Глава")]
    [Range(1, 1)]
    public int chapter;
    [Header("Порядок арен")]
    [Range(0, 3)]
    public int[] arenaStack;
    [Header("Отступ спавна от края экрана")]
    [Range(0f, 200)]
    public float step;

    private GameObject[] Areas = new GameObject[4];
    private GameObject curentArea;
    private int arenaCounter;

    void Awake()
    {
        // Установка положения
        gameObject.GetComponent<Transform>().position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).x + step, 0f);
        // Подключение арен
        Areas[0] = gameObject.transform.Find("Short Area").gameObject;
        Areas[1] = gameObject.transform.Find("Mid Area").gameObject;
        Areas[2] = gameObject.transform.Find("Big Area").gameObject;
        Areas[3] = gameObject.transform.Find("Boss Area").gameObject;
    }

    void Start()
    {
        curentArea = Areas[arenaStack[arenaCounter++]].GetComponent<AreaController>().Spawn(); // Вызываем первую арену
    }

    void Update ()
    {
        if (curentArea != null) // Если есть активная арена
            return;
        if (arenaCounter < arenaStack.Length) // Пока ещё есть арены в очереди
            curentArea = Areas[arenaStack[arenaCounter++]].GetComponent<AreaController>().Spawn();
    }
}
