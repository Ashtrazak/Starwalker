using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [Header("Наносимые повреждения")]
    [Range(0.1f, 10f)]
    public float damage;
    //
    [Header("Тэг объекта")]
    public string collisionTag;

    //[Header("Анимация взрыва снаряда")]
    //public GameObject effectPrefab;

    private void OnCollisionStay2D(Collision2D collision) // Обработка столкновения снаряда
    {
        //Debug.Log("1");

        if (collision.gameObject.tag != collisionTag) // Выбор множества целей по тэгу
            return;

        Debug.Log("2");

        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage * Time.deltaTime); // Нанести цели урон
        else
            collision.gameObject.GetComponent<Health>().TakeDamage(damage * Time.deltaTime); // Нанести цели урон
        //Destroy(Instantiate(effectPrefab, GetComponent<Transform>().position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 0.5f);
        //Destroy(gameObject);
    }
}
