using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum dir // Направление двжения
{
    left = -1,
    right = 1,
}

public class SimpleMove : MonoBehaviour
{
    private Transform _transform;

    [Header("Скорость перемещения")]
    public dir direction = dir.left;
    [Header("Скорость перемещения")]
    [Range(10f, 10000f)]
    public float speed = 100;
    [Header("Угол относительно оси X")]
    [Range(-90f, 90f)]
    public float angle = 0;
    [Header("Время жизни объекта")]
    [Range(0f, 300f)]
    public float timeToDestroy = 10;

    void Awake ()
    {
        _transform = GetComponent<Transform>();
        if (timeToDestroy>0)
            Destroy(gameObject, timeToDestroy);
    }
	
	void Update ()
    {
        _transform.Translate(new Vector2((int)direction*speed * Mathf.Cos(angle*Mathf.PI/180f) * Time.deltaTime, speed * Mathf.Sin(angle* Mathf.PI / 180f) * Time.deltaTime));
    }
}
