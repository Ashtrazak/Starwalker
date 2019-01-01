﻿using UnityEngine;

public class BulletOptions : MonoBehaviour
{
    [Header("Наносимый урон")]
    [Range(1, 100)]
    public int damage = 1;

    [Header("Тэг столкновения")]
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D collision) // Обработка столкновения снаряда
    {
        if (collision.gameObject.tag != collisionTag) // Выбор множества целей по тэгу
            return;

        collision.gameObject.GetComponent<EnemyBaseParameters>().TakeDamage(damage); // Нанести цели урон
    }
}
