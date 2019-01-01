using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Задние фоны")]
    public Sprite[] backgroundSprite;

    void Awake ()
    {
        // Установить рандомный фон
        // GetComponent<SpriteRenderer>().sprite = backgroundSprite[Random.Range(0, backgroundSprite.Length)];
    }
}

