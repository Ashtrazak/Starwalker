using UnityEngine;

public class EnemySet : MonoBehaviour
{
    [Header("Солдат")]
    [Tooltip("Обычные противники с оружием для короткой дистанции")]
    public GameObject[] solderEnemy;
    [Header("Стрелок")]
    [Tooltip("Обчные стреляющие противники")]
    public GameObject[] rangerEnemy;
    [Header("Препятствие")]
    [Tooltip("Блоки пути и причины для уклонения")]
    public GameObject[] obstruction;
    [Header("Ловушка")]
    [Tooltip("Объекты со специальным поведением")]
    public GameObject[] trap;
    [Header("МиниБосс")]
    [Tooltip("Сильный притивник")]
    public GameObject[] miniBoss;
    [Header("Босс")]
    [Tooltip("Крайне сильный противник с уникальным поведением")]
    public GameObject[] boss;

    // Функции получения определённого противника
    public GameObject GetSolder() 
    {
        return solderEnemy[Random.Range(0, solderEnemy.Length)];
    }
    public GameObject GetSolder(int number)
    {
        return solderEnemy[number];
    }
    public GameObject GetRanger()
    {
        return rangerEnemy[Random.Range(0, rangerEnemy.Length)];
    }
    public GameObject GetRanger(int number)
    {
        return rangerEnemy[number];
    }
    public GameObject GetObstruction()
    {
        return obstruction[Random.Range(0, obstruction.Length)];
    }
    public GameObject GetObstruction(int number)
    {
        return obstruction[number];
    }
    public GameObject GetTrap()
    {
        return trap[Random.Range(0, trap.Length)];
    }
    public GameObject GetTrap(int number)
    {
        return trap[number];
    }
    public GameObject GetMiniBoss()
    {
        return miniBoss[Random.Range(0, miniBoss.Length)];
    }
    public GameObject GetMiniBoss(int number)
    {
        return miniBoss[number];
    }
    public GameObject GetBoss()
    {
        return boss[Random.Range(0, boss.Length)];
    }
    public GameObject GetBoss(int number)
    {
        return boss[number];
    }
}

