using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform _transform;

    public GameObject gameController;

    [Tooltip("Прочность")]
    [SerializeField] private int healthPoint;

    [Tooltip("Скорость")]
    [SerializeField] private float maxSpeed;

    [Tooltip("Невосприимчивость к урону")]
    [SerializeField] private bool isImmortal;

    [Tooltip("Префаб взрыва при уничтожении игрока")]
    public GameObject explosionPref;

    private bool isMove = false;            // Состояние: "есть движение"/"нет движения"
    private Vector3 clickPosition;          // Координаты точки касания к экрану
    private Vector3 deltaMove;              // Расстояние от корабля до точки касания к экрану
    private float xMin, xMax, yMin, yMax;   // Границы камеры

    private void OnValidate()
    {
        if (healthPoint <= 0)
            healthPoint = 1;
        if (maxSpeed < 0)
            maxSpeed = 0;
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    public void TakeDamage(int damage)
    {
        if (isImmortal)
            return;

        healthPoint -= damage;
        if (healthPoint <= 0)
        {
            Destroy(Instantiate(explosionPref, GetComponent<Transform>().position, Quaternion.identity), 0.5f);
            Destroy(gameObject);
        }
    }

    void Awake ()
    {
        _transform = GetComponent<Transform>();

        // Граничные положения для игрока
        xMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        xMax= Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        yMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        yMax = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
    }

    private void Start()
    {
        clickPosition = _transform.position;
    }

    void Update ()
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
            new Vector3(Mathf.Clamp(clickPosition.x - deltaMove.x, xMin, xMax), Mathf.Clamp(clickPosition.y - deltaMove.y, yMin, yMax), _transform.position.z),
            maxSpeed * Time.deltaTime);
    }
}
