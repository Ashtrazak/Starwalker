using UnityEngine;

public class DamageContactObject : MonoBehaviour
{
    [Header("Наносимый объекту урон")]
    [Range(1, 100)]
    public int damage = 1;
    //
    [Header("Тэг объекта")]
    public string collisionTag;
    //
    [Header("Анимация взрыва после столкновения с объектом")]
    public GameObject effectPrefab;

    private void OnCollisionEnter2D(Collision2D collision) // Обработка столкновения снаряда
    {
        if (collision.gameObject.tag != collisionTag) // Выбор множества целей по тэгу
            return;

        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage); // Нанести цели урон
        else
            collision.gameObject.GetComponent<Health>().TakeDamage(damage); // Нанести цели урон

        Destroy(Instantiate(effectPrefab, GetComponent<Transform>().position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 0.5f);
        Destroy(gameObject);
    }
}
