using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;
using UnityEngine.Events;
public class EventCenter : MonoBehaviour
{
    private EventCenter() { }

    private Dictionary<E_EventType, IEventInfo> eventDic = new Dictionary<E_EventType, IEventInfo>();

    /*�޲�****************************************************************/

    public void AddEventListener(E_EventType name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            //����asΪ����
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

    /*�в�****************************************************************/
    public void AddEventListener<T>(E_EventType name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            //��Ϊ�Ǹ��ࣨIEventInfo��װ���ࣨEventInfo<T>������asΪ���ࣨEventInfo<T>������ʹ�����е�actions
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

//��Ϊ�˰�����Ӧ�۲��� ����ί�е� ��
public class EventInfo : IEventInfo
{
    public UnityAction actions;

    //�����۲��� ��Ӧ�� ������Ϣ ��¼������
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

//�˽ӿ����������滻ԭ�� װ������� ���࣬Ŀ�����ִ�����е�
public interface IEventInfo
{
}
public enum E_EventType
{
    E_NoHealth,//����Ϊ0
    E_GetSaved,//������
    E_NoSave,//û���˾�
    E_ToBeChosen,//��ѡ��
    E_GameStart,//��Ϸ��ʼ
    E_AfterStart,//����֮��
    E_Action,//����ж�
    E_FinishReceive,//��������
    E_FinishPlay,//��������
    E_FinishAbandon,//��������
    E_FinishBeChosen//������ѡ��

}