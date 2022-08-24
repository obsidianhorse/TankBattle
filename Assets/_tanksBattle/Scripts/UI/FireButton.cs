using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action ButtonSelected;
    
    
    private bool _pressed = false;




    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }




    private void FixedUpdate()
    {
        if (_pressed == true)
        {
            ButtonSelected?.Invoke();
        }
    }
}
