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
    [Header("Время отведённое на проведение соответствующего игрового события")]
    [Range(0f, 25f)]
    public float[] iventTime = new float[5];
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
    private int iventIndex; // Номер игрового события

    void Start()
    {
        SpawnIvent();
    }
    void Update ()
    {
        if (curentIvent != null) // Если есть активная арена
            return;
        if (iventIndex < iventSequence.Length) // Пока ещё есть арены в очереди
            SpawnIvent();
        else if (loopIvents) // Если порядок событий зациклен
        {
            iventIndex = 0;
            SpawnIvent();
        }
    }

    void SpawnIvent()
    {
        int iventType = iventSequence[iventIndex]; // Получаем тип события
        curentIvent = Instantiate(ivent[iventType], transform.position, Quaternion.identity, transform); // Вызываем первую по списку арену
        //curentIvent.transform.parent = transform; // Прикрепляем ивент к этому объекту
        if (iventTime[iventType] != 0f) // (Для значения 0 арена не будет удалена по таймеру)
            Destroy(curentIvent, iventTime[iventType]); // Устанавливаем таймер на ивент соответствующего типа
        iventIndex++;
    }
}
