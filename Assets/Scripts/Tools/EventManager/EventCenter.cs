using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;
using UnityEngine.Events;
public class EventCenter : BaseSingleton<EventCenter>
{
    public EventCenter() { }

    private Dictionary<E_EventType, IEventInfo> eventDic = new Dictionary<E_EventType, IEventInfo>();

    /*无参****************************************************************/

    public void AddEventListener(E_EventType name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            //父先as为子类
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action));
        }
    }

    public void EventTrigger(E_EventType name)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions?.Invoke();
        }
    }

    public void RemoveEventListener(E_EventType name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }
    

    /*有参****************************************************************/
    public void AddEventListener<T>(E_EventType name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            //因为是父类（IEventInfo）装子类（EventInfo<T>），先as为子类（EventInfo<T>），再使用其中的actions
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action));
        }
    }
    public void EventTrigger<T>(E_EventType name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }
    public void RemoveEventListener<T>(E_EventType name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void ClearAllEvents()
    {
        eventDic.Clear();
    }

}

//是为了包裹对应观察者 函数委托的 类
public class EventInfo : IEventInfo
{
    public UnityAction actions;

    //真正观察者 对应的 函数信息 记录在其中
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;

    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}

//此接口用于里氏替换原则 装载子类的 父类，目标调父执行子中的
public interface IEventInfo
{
}
public enum E_EventType
{
    E_NoHealth,//生命为0
    E_GetSaved,//被救了
    E_NoSave,//没有人救
    E_ToBeChosen,//被选择
    E_GameStart,//游戏开始
    E_AfterStart,//开局之后
    E_Action,//玩家行动
    E_FinishReceive,//结束发牌
    E_FinishPlay,//结束出牌
    E_FinishAbandon,//结束弃牌
    E_FinishBeChosen//结束被选择

}
