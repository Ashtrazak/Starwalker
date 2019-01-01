using UnityEngine;

public class IventDisposer : MonoBehaviour
{
    [Header("Глава")]
    [Range(1, 1)]
    public int chapter = 1;
    //
    [Header("Игровые события")]
    public GameObject[] ivent = new GameObject[5];
    //
    [Header("Порядок запуска игровых событий")]
    [Tooltip(   "0 - Пауза \n" + "1 - Вызвать боевую зону \n" + "2 - Вызвать препятствия \n" + "3 - Вызвать испытание \n" + "4 - Босс")]
    [Range(0, 4)]
    public int[] iventSequence;
    //
    [Header("Зациклить смену ивентов")]
    public bool loopIvents;
    //
    private GameObject curentIvent; // Текущее событие
    private int iventGeneratorIndex; // Номер игрового события

    void Awake()
    {
    }
    void Start()
    {
        //curentIventGenerator = iventGenerator[iventStack[iventGeneratorIndex++]].GetComponent<AreaController>().Spawn(); // Вызываем первую арену
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
