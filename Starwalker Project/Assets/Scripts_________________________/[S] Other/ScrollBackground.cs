using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [Range(0f, 1000f)]
    public float scrollSpeed;
    public float tileSize;

    private Transform _transform;

	void Start ()
    {
        _transform = GetComponent<Transform>();
        tileSize *= _transform.localScale.x / 100f;
    }
	void Update ()
    {
        _transform.position = new Vector3(_transform.position.x, Mathf.Repeat(Time.time * -scrollSpeed, tileSize), _transform.position.z);
    }
}
