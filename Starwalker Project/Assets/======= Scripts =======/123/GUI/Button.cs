using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float timeDelay;

    public UnityEvent ClickEvent;

    public void OnPointerClick(PointerEventData evenData)
    {
        StartCoroutine(ClickCorutine());
    }

    private IEnumerator ClickCorutine()
    {
        yield return new WaitForSeconds(timeDelay);
        ClickEvent.Invoke();
    }
}
