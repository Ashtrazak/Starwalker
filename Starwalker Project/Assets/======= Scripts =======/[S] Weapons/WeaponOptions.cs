using UnityEngine;

public class WeaponOptions : MonoBehaviour
{
    [Header("Набор снарядов Снаряд")]
    public GameObject[] bulletPref;

    //Позиции спавна снарядов
    private Transform[] bulletPosition;

    [Header("Время между выстрелами каждого снаряда")]
    [Range(0.01f, 5f)]
    public float[] attackSpeed;
    private float[] attackSpeedCounter;

    [Header("Скорость полёта каждого снаряда")]
    [Range(10f, 10000f)]
    public float[] bulletSpeed;

    [Header("Урон каждого снаряда")]
    [Range(1, 100)]
    public int[] bulletDamage;

    void Awake ()
    {
        attackSpeedCounter = new float[attackSpeed.Length]; // Число счётчиков
        // Подключение позиций спавна снарядов
        bulletPosition = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            bulletPosition[i] = transform.GetChild(i);
    }
	void Update ()
    {
         for (int i = 0; i < bulletPosition.Length; i++)
             if (attackSpeedCounter[i] < attackSpeed[i])
                 attackSpeedCounter[i] += Time.deltaTime;
             else
             {

                GameObject bullet = Instantiate(bulletPref[i], bulletPosition[i].position, Quaternion.identity); // Создаём снаряды в соответствующих точках
                bullet.GetComponent<SimpleMove>().speed = bulletSpeed[i];
                bullet.GetComponent<SimpleMove>().angle = 90;
                bullet.GetComponent<DamageContactObject>().damage = bulletDamage[i];

                attackSpeedCounter[i] = 0f;
             }
    }

}
