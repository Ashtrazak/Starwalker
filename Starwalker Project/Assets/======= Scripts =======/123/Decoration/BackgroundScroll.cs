using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Transform _transform;

    [Tooltip("Скорость прокрутки фона")]
    [SerializeField] private float scrollSpeed;

    [Tooltip("Размер одного тайла заднего фона")]
    [SerializeField] private float tileSize;

    [Tooltip("Масштабирование одного тайла заднего фона")]
    [SerializeField] private float tileScale;

    public float speedScale = 1f; // Множитель скорости

    void OnValidate()
    {
        if (scrollSpeed < 0)
            scrollSpeed = 0;
        if (tileSize < 0)
            tileSize = 0;
        if (tileScale < 0)
            tileScale = 0;
    }

    void Awake()
    {
        _transform = GetComponent<Transform>();
        tileSize *= tileScale / 100f;
    }
	void Update ()
    {
        _transform.position += new Vector3(0f, Time.deltaTime * -1 * scrollSpeed * speedScale, 0f);
        if (_transform.position.y <= -tileSize)
            _transform.position = new Vector3(_transform.position.x, 0f, _transform.position.z);
    }
}
