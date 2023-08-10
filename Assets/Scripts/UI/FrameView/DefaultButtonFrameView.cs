using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultButtonFrameView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerExitHandler, 
    IPointerUpHandler
{
    [SerializeField] private AudioClip _buttonClick;
        
    public void OnPointerClick(PointerEventData eventData)
    {
        UIAudio.GetInstance().PlayAudio(_buttonClick);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.transform
            .DOScale(0.94f, 0.1f)
            .SetLink(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform
            .DOScale(1.0f, 0.01f)
            .SetLink(gameObject);;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.transform
            .DOScale(1.0f, 0.01f)
            .SetLink(gameObject);;
    }
}
