using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpin : MonoBehaviour {

    public enum dir // Направление вращения
    {
        left = -1,
        right = 1,
    }
    private Transform _transform;

    [Header("Направление вращения")]
    public dir direction = dir.left;
    [Header("Скорость перемещения")]
    [Range(10f, 10000f)]
    public float speed = 100;

    void Awake()
    {
        _transform = GetComponent<Transform>();
    }
	void FixedUpdate ()
    {
        _transform.Rotate(new Vector3(0,0, speed) * Time.fixedDeltaTime);
    }
}
