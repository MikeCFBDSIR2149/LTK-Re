using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CardType
{
    Normal,
    Equipment,
    Influence
}

public class CardFactory <T> where T :class
{
    public Dictionary<string,List<T>> normalFactory = new Dictionary<string,List<T>>();
    public Dictionary<string,List<T>> equipmentFactory = new Dictionary<string,List<T>>();
    public Dictionary<string,List<T>> influenceFactory = new Dictionary<string,List<T>>();
    /// <summary>
    /// 随机拿一张牌
    /// </summary>
    /// <param name="type">从哪个牌库里拿</param>
    /// <returns>T</returns>
    public T GetARandomCardFromSingle(CardType type)
    {
        int randomIndex = UnityEngine.Random.Range(0,TypeToFactory(type).Count);
        List<T> cards= new List<T>();
        foreach (List<T> item in TypeToFactory(type).Values)
        {
            if (randomIndex==0)
            {
                cards = item;
                break;
            }
            randomIndex--;
        }
        T card = cards[UnityEngine.Random.Range(0, cards.Count)];
        RemoveCard(type, card);
        return card;
    }
    /// <summary>
    /// 从所有牌库中随机拿一张牌
    /// </summary>
    /// <returns>T</returns>
    public T GetARandomCardFromAll(CardType escape)
    {
        Array cardTypes = Enum.GetValues(typeof(CardType));
        CardType randomType = (CardType)cardTypes.GetValue(UnityEngine.Random.Range(0, cardTypes.Length));
        return GetARandomCardFromSingle(randomType);
    }
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
