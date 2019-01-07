using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    private Transform _transform;

    [Header("Скорость перемещения")]
    [Range(10f, 10000f)]
    public float speed = 100;
    [Header("Угол относительно оси X")]
    [Tooltip("0 - горизонтально вправо")]
    [Range(-360f, 360f)]
    public float angle = -90;

    void Awake ()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        _transform.position += new Vector3(speed * Mathf.Cos(angle * Mathf.PI / 180f) * Time.deltaTime, speed * Mathf.Sin(angle * Mathf.PI / 180f) * Time.deltaTime, 0f);
    }
}
