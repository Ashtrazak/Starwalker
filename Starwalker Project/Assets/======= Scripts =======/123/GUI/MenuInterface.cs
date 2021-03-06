﻿using System.Collections;
using UnityEngine;

public class MenuInterface : MonoBehaviour
{
    [SerializeField] private float timeDelayOn;
    [SerializeField] private float timeDelayOff;

    // Включить интерфейс меню
    public void MenuInterfaceOn()
    {
        StartCoroutine(On());
    }
    private IEnumerator On()
    {
        yield return new WaitForSeconds(timeDelayOn);
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }

    // Выключить интерфейс меню
    public void MenuInterfaceOff()
    {
        StartCoroutine(Off());
    }
    private IEnumerator Off()
    {
        yield return new WaitForSeconds(timeDelayOff);
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

}
