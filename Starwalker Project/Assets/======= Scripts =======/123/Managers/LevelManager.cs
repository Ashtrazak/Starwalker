
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /*
    private GameController gameManager;

    void Awake()
    {
        gameManager = GetComponentInParent<GameController>();
    }

    void OnEnable()
    {
        gameManager.links.player.GetComponent<PlayerComingScene>().enabled = true; // команда игроку появиться на сцене

        

        // Отрисовать интерфейс меню (C Задержкой)
        // Дать команду бэкграунду проиграть эффект скорости на уменьшение (Сразу)
        // Дать команду бэкграунду подключить фон меню (Сразу)
        // Дать команду сделать эффект приближения (Сразу)
    }

    void OnDisable()
    {
        gameManager.links.player.GetComponent<PlayerLeaveScene>().enabled = true; // команда игроку уйти со сцены

        gameManager.links.player.GetComponent<PlayerController>().enabled = false; // Отключить игроку взаимодействие
        // Стереть интерфейс меню (Сразу)
        // Дать команду бэкграунду проиграть эффект скорости на увеличеие (Сразу)
        // Дать команду сделать эффект отдаления (Сразу)
    }


    private void Update()
    {
        // Тестовый выход со сцены
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.gameState = GameState.MainMenu; // Установка состояния игры
            this.enabled = false; // Отключаем главное меню
        }
    }
    */
}
