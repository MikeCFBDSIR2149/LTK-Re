using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string Name;
    public Rank rank;
    public Suit suit;

    public Card(Rank rank,Suit suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    //��Ҫ�������
    //public virtual void Skill() { }

}
