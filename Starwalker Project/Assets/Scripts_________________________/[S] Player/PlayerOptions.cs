using UnityEngine;

public class PlayerOptions : MonoBehaviour
{
    private Transform _transform;

    [Header("Скорость перемещения")]
    [Range(1.5f, 10f)]
    public float speed;

    private bool isMove = false; // Состояние: "есть движение"/"нет движения"
    private Vector3 clickPosition; // Координаты точки касания к экрану
    private Vector3 deltaMove; // Расстояние от корабля до точки касания к экрану
    private float x1, x2, y1, y2; // Границы камеры

    void Awake()
    {
        _transform = GetComponent<Transform>();
        x1 = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        x2 = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        y1 = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        y2 = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0) // Касание
        {
            clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
            if (!isMove)
            {
                deltaMove = clickPosition - _transform.position;
                isMove = true;
            }
        }
        else if (Input.GetMouseButton(0)) // Клик мыши
        {
            clickPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            if (!isMove)
            {
                deltaMove = clickPosition - _transform.position;
                isMove = true;
            }
        }
        else
            isMove = false;
            
        // Плавное перемещение
        _transform.position = 
            Vector3.Lerp(_transform.position, 
            new Vector3(Mathf.Clamp(clickPosition.x - deltaMove.x, x1, x2), Mathf.Clamp(clickPosition.y - deltaMove.y, y1, y2), _transform.position.z),
            speed*Time.fixedDeltaTime);
    }
}