using UnityEngine;

public class PlayerSetScale : MonoBehaviour
{
    private Transform _transform;

	void Awake ()
    {
        _transform = GetComponent<Transform>();
    }

    public void SetScale(float scale)
    {
        _transform.localScale = new Vector3(scale, scale, _transform.localScale.z);
    }
}
