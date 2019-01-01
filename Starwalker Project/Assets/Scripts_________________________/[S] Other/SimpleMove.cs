using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    private Transform _transform;

    [Header("Скорость перемещения")]
    [Range(10f, 10000f)]
    public float speed = 100;
    [Header("Угол относительно оси X")]
    [Tooltip("0 - горизонтально вправо")]
    [Range(0f, 360f)]
    public float angle = -90;
    [Header("Время жизни объекта")]
    [Range(0f, 300f)]
    public float timeToDestroy = 10;

    void Awake ()
    {
        _transform = GetComponent<Transform>();
        if (timeToDestroy>0)
            Destroy(gameObject, timeToDestroy);
    }
	
	void FixedUpdate ()
    {
        _transform.position += new Vector3(speed * Mathf.Cos(angle * Mathf.PI / 180f) * Time.fixedDeltaTime, speed * Mathf.Sin(angle * Mathf.PI / 180f) * Time.fixedDeltaTime, 0f);
    }
}
