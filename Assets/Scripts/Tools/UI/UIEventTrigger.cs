using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// UI事件监听类,相当于Button的拓展类，挂在UI上
/// </summary>
//注册全局委托
public delegate void PointerEventHandler(PointerEventData eventData);

public class UIEventTrigger : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler,IDragHandler,IPointerEnterHandler,IPointerExitHandler
{
    //单击，按下，抬起三个事件
    public event PointerEventHandler PointerDown;
    public event PointerEventHandler PointerUp;
    public event PointerEventHandler PointerClick;
    public event PointerEventHandler PointerDrag;
    public event PointerEventHandler PointerEnter;
    public event PointerEventHandler PointerExit;

    //如果事件不为空，调用该事件
    //eventData帮助寻找被触发Button所在的物体
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerClick != null) PointerClick(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (PointerDown != null) PointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PointerUp != null) PointerUp(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (PointerDrag != null) PointerDrag(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PointerEnter != null) PointerEnter(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (PointerExit != null) PointerExit(eventData);
    }
}
