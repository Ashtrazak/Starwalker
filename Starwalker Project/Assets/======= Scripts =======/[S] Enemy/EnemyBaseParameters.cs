using UnityEngine;

public class EnemyBaseParameters : MonoBehaviour
{
    [Header("Здоровье")]
    [Range(1,1000)]
    public int HealthPointMax = 3;
    private int HealthPoint;
    [Header("Невосприимчивость к урону")]
    public bool isImmortal = false;

    [Header("Взрыв при уничтожении")]
    public GameObject explosionPref;

    void Awake ()
    {
        HealthPoint = HealthPointMax;
    }
	void Update ()
    {
		
	}

    public void TakeDamage(int damage) // Получение урона
    {
        if (isImmortal)
            return;

        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            Destroy(Instantiate(explosionPref, GetComponent<Transform>().position, Quaternion.identity), 0.5f);
            Destroy(gameObject, 0.01f);
            GetComponent<EnemyBaseParameters>().enabled = false;
        }

        //VisualDamageReaction();
    }
    public void VisualDamageReaction() // Визуальная реакция на получение урона
    {
        SpriteRenderer SR = gameObject.GetComponent<SpriteRenderer>();
        if ((float)(HealthPoint / HealthPointMax) < 34f)
            SR.color = new Vector4(SR.color.r, SR.color.b * 0.85f, SR.color.g * 0.85f, SR.color.a);
        else if ((float)(HealthPoint / HealthPointMax) < 66f)
                SR.color = new Vector4(SR.color.r, SR.color.b * 0.70f, SR.color.g * 0.70f, SR.color.a);
    }


}
