using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public List<BasicCard> basic = new List<BasicCard>();
    public List<SkillCard> skill = new List<SkillCard>();
    public List<EquipCard> equip = new List<EquipCard>();

    void Start()
    {
        InitCard();
        CreatDeck();
        Shuffle();
    }

    //初始化卡牌
    private void InitCard()
    {

    }

    //生成牌组
    private void CreatDeck()
    {
        deck.Clear();
        deck.AddRange(basic);
        deck.AddRange(skill);
        deck.AddRange(equip);
    }

    //洗牌
    private void Shuffle()
    {
        System.Random rng = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}
