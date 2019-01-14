using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundSprite : MonoBehaviour
{
    [SerializeField] private Sprite menuBackGroundSprite;
    [SerializeField] private List<Sprite> backGroundSprite;

    // Спрайт для меню
    public void SetMenuSprite()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = menuBackGroundSprite;
    }

    // Спрайты для уровней
    public void SetLevelSprite()
    {
        int index = 0;
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = backGroundSprite[index];
    }
}
