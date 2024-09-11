using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CardType
{
    Normal,
    Weapon,
    Equipment,
    Influence
}

public class CardFactory <T> where T :class
{
    public Dictionary<string,List<T>> normalFactory = new Dictionary<string,List<T>>();
    public Dictionary<string,List<T>> weaponFactory = new Dictionary<string,List<T>>();
    public Dictionary<string,List<T>> equipmentFactory = new Dictionary<string,List<T>>();
    public Dictionary<string,List<T>> influenceFactory = new Dictionary<string,List<T>>();
    public bool AddCard( CardType type, string cardName,T card)
    {
        Dictionary<string, List<T>> dic = TypeToFactory(type);
        if (dic == null) return false;
        if (normalFactory.ContainsKey(cardName))
        {
            normalFactory[cardName].Add(card);
        }
        else
        {
            normalFactory.Add(cardName, new List<T>() { card });
        }
        return true;
    }
    private Dictionary<string, List<T>> TypeToFactory(CardType type)
    {
        Dictionary<string,List<T>> dic = null;
        switch (type)
        {
            case CardType.Normal:
                dic = normalFactory;
                break;
            case CardType.Weapon:
                dic = weaponFactory;
                break;
            case CardType.Equipment:
                dic = equipmentFactory;
                break;
            case CardType.Influence:
                dic = influenceFactory;
                break;
        }
        return dic;
    }

    public bool RemoveCard(CardType type,T card)
    {
        Dictionary<string, List<T>> dic = TypeToFactory(type);
        if (dic == null) return false;
        foreach (var item in normalFactory.Keys)
        {
            List<T> cardList = normalFactory[item];
            if (cardList.Contains(card))
            {
                if (cardList.Count == 1)
                {
                    normalFactory.Remove(item);
                    return true;
                }
                cardList.Remove(card);
                return true;
            }
        }
        return false;
    }
    public int CountCardNum(CardType type)//出错返回-1
    {
        Dictionary<string,List<T>> dic = TypeToFactory(type);
        if (dic == null)
        {
            Debug.LogError("Something wrong when counting cards!");
            return -1; 
        }
        int cardCount = 0;
        foreach(var item in dic.Values)
        {
            cardCount += item.Count;
        }
        return cardCount;
    }
    public int CountCardNum()
    {
        int cardCount = 0;
        Array cardTypes = Enum.GetValues(typeof(CardType));
       foreach (CardType item in cardTypes)
        {
            cardCount+=CountCardNum(item);
        }
        return cardCount;
    }

}
