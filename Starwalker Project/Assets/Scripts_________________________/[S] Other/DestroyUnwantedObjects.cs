﻿using UnityEngine;

public class DestroyUnwantedObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(collision.gameObject);
    }
}
