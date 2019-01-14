using System.Collections;
using UnityEngine;

public class StarFieldSpeedDown : MonoBehaviour
{ 
    private Transform _transform;

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
        _transform = gameObject.GetComponent<Transform>();
        for (int i = 0; i < transform.childCount; i++) // Убирает рассинхронизацию значений при старте игры
        {
            var main = _transform.GetChild(i).GetComponent<ParticleSystem>().main;
            main.simulationSpeed = StartValue;
        }
    }
    void OnEnable()
    {
        GetComponent<StarFieldSpeedUp>().enabled = false; // Отключаем скрипт противоположного действия
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

        for (int i = 0; i < transform.childCount; i++)
        {
            var main = _transform.GetChild(i).GetComponent<ParticleSystem>().main;
            main.simulationSpeed = curentValue;
        }
    }
}