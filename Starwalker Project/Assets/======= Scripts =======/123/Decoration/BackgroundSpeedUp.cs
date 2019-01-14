using System.Collections;
using UnityEngine;

public class BackgroundSpeedUp : MonoBehaviour
{
    private BackgroundScroll background;

    [Tooltip("Начальное значени")]
    [SerializeField] private float StartValue;

    [Tooltip("Конечное значение")]
    [SerializeField] private float targetValue;

    [Tooltip("Скорость изменения значения")]
    [SerializeField] private float changeValueSpeed;

    [Tooltip("Ускорение изменения значения")]
    [SerializeField] private float changeValueAcceleration;

    [Tooltip("Допустимая разница между изменяемой величиной и её конечным значением")]
    [SerializeField] private float valueBorder;

    [Tooltip("Время до старта изменения значения")]
    [SerializeField] private float timeDelay;

    private float curentValue;
    private float curentChangeValueSpeed;
    private bool isReady = false;

    void OnValidate()
    {
        if (changeValueSpeed < 0)
            changeValueSpeed = 0;
        if (changeValueAcceleration < 0)
            changeValueAcceleration = 0;
        if (valueBorder < 0)
            valueBorder = 0;
        if (timeDelay < 0)
            timeDelay = 0;
    }
    void Awake()
    {
        background = GetComponent<BackgroundScroll>();
    }
    void OnEnable()
    {
        GetComponent<BackgroundSpeedDown>().enabled = false; // Отключаем скрипт противоположного действия
        curentChangeValueSpeed = changeValueSpeed;
        curentValue = StartValue;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeDelay);
        isReady = true;
    }

    void Update()
    {
        if (!isReady)
            return;

        if (Mathf.Abs(curentValue - targetValue) < valueBorder)
        {
            curentValue = targetValue; // Коректировка положения до конечного 
            isReady = false;
            this.enabled = false;
        }
        else
        {
            curentValue = Mathf.Lerp(curentValue, targetValue, curentChangeValueSpeed * Time.deltaTime);
            curentChangeValueSpeed += changeValueAcceleration; // Реализуем ускорение
        }

        background.speedScale = curentValue;
    }
}