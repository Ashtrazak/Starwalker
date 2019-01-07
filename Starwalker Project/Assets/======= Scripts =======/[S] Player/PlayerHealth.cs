using UnityEngine;

public class PlayerHealth : Health
{
    // Добавить реакцию игры на уничтожение игрока

    public override void TakeDamage(float damage) // Получение урона
    {
        if (isImmortal)
            return;

        healthPoint -= damage;
        if (healthPoint <= 0f)
        {
            Destroy(Instantiate(explosionPref, GetComponent<Transform>().position, Quaternion.identity), 0.5f);
            Destroy(gameObject);
        }
        //
        //Debug.Log(healthPoint);
    }
}
    