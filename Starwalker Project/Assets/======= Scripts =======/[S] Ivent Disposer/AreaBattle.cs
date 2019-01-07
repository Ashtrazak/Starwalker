using UnityEngine;

public class AreaBattle : MonoBehaviour
{
    private EnemySet EnemyContainer; // Контейнер с противниками
    private float interval;

    void Awake ()
    {
        EnemyContainer = GameObject.Find("Enemy Set").GetComponent<EnemySet>(); // Подключаем контейнер с проттивниками
        interval = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
    }
    void Start()
    {
        //Spawn(Random.Range(0,1));
        Spawn(0); //-Тестовая команда-//
    }

    void Spawn(int variant)
    {
        int temp = Random.Range(0, 10); 
        if (temp < 3)
            Instantiate(EnemyContainer.GetRanger(), new Vector3(transform.position.x + Random.Range(-interval, interval), transform.position.y, transform.position.z), EnemyContainer.GetSolder().transform.rotation);
        else
            Instantiate(EnemyContainer.GetSolder(), new Vector3(transform.position.x + Random.Range(-interval, interval), transform.position.y, transform.position.z), EnemyContainer.GetSolder().transform.rotation);
    }
}
