using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Снаряд")]
    public GameObject[] bulletPref;

    [Header("Позиция снаряда")]
    public Transform[] bulletPosition;

    [Header("Время между выстрелами")]
    [Range(0.01f, 5f)]
    public float[] attackSpeed;
    private float[] attackSpeedCounter;

    void Awake ()
    {
        // Проверка на случай, если будут не указано одинаковое количество параметров
        if ((bulletPref.Length != attackSpeed.Length)||(attackSpeed.Length != bulletPosition.Length)|| (bulletPref.Length != bulletPosition.Length))
            throw new System.InvalidOperationException("Длинны масивов не сответствуют: WeaponController");
        attackSpeedCounter = new float[attackSpeed.Length];
    }

	void Update ()
    {
        for (int i = 0; i < bulletPosition.Length; i++)
            if (attackSpeedCounter[i] < attackSpeed[i])
                attackSpeedCounter[i] += Time.deltaTime;
            else
            {
                // Создаём снаряды в соответствующих точках
                Instantiate(bulletPref[i], bulletPosition[i].position, Quaternion.identity);
                attackSpeedCounter[i] = 0f;
            }
    }
}
