using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    private Transform _transform;
    [Header("Скорость перемещения")]
    [Range(100f, 10000f)]
    public float speed;
    [Header("Угол относительно оси X")]
    [Range(-90f, 90f)]
    public float angle;
    [Header("Время жизни объекта")]
    [Range(1f, 30f)]
    public float timeToDestroy;

    void Awake ()
    {
        _transform = GetComponent<Transform>();
        Destroy(gameObject, timeToDestroy);
    }
	
	void Update ()
    {
        _transform.Translate(new Vector2(speed * Mathf.Cos(angle*Mathf.PI/180f) * Time.deltaTime, speed * Mathf.Sin(angle* Mathf.PI / 180f) * Time.deltaTime));
    }
}
