using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Vector2 vectorMove;

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Translate(speed*vectorMove, Space.World);
	}
}
