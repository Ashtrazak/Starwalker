using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Прочность корабля")]
    [Range(1f, 1000f)]
    public float healthPointMax = 3f;
    protected float healthPoint;
    //
    [Header("Невосприимчивость к урону")]
    public bool isImmortal = false;
    //
    [Header("Взрыв при уничтожении")]
    public GameObject explosionPref;

    void Awake ()
    {
        healthPoint = healthPointMax;
    }

    public virtual void TakeDamage(float damage) // Получение урона
    {
        if (isImmortal)
            return;

        healthPoint -= damage;
        if (healthPoint <= 0f)
        {
            Destroy(Instantiate(explosionPref, GetComponent<Transform>().position, Quaternion.identity), 0.5f);
            Destroy(gameObject);
        }
    }
}
