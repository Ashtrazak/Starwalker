using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Глава")]
    [Range(1, 1)]
    public int chapter = 1;

    [Header("Порядок ивентов")]
    [Tooltip(   "0 - Блок рядовых противников \n" +
                "1 - Избегание препятствий \n" +
                "2 - Мини-босс \n" +
                "3 - Босс")]
    [Range(0, 3)]
    public int[] iventStack;

    [Header("Зациклить смену ивентов")]
    public bool loopIvents;

    //private GameObject[] Areas = new GameObject[4];
    //private GameObject curentArea;
    //private int arenaCounter;

    void Awake()
    {
        // Подключение арен
        //Areas[0] = transform.GetChild(0).GetChild(0).gameObject;
        //Areas[1] = transform.GetChild(0).GetChild(1).gameObject;
        //Areas[2] = transform.GetChild(0).GetChild(2).gameObject;
        //Areas[3] = transform.GetChild(0).GetChild(3).gameObject;
    }

    void Start()
    {
       // curentArea = Areas[arenaStack[arenaCounter++]].GetComponent<AreaController>().Spawn(); // Вызываем первую арену
    }

    void Update ()
    {
        /*
        if (curentArea != null) // Если есть активная арена
            return;
        if (arenaCounter < arenaStack.Length) // Пока ещё есть арены в очереди
            curentArea = Areas[arenaStack[arenaCounter++]].GetComponent<AreaController>().Spawn();
        */
    }
}
