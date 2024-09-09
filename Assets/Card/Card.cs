using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    public string Name;
    public Rank rank;
    public Suit suit;
    public BaseSkill skill;

    public Card(Rank rank, Suit suit, BaseSkill skill)
    {
        this.rank = rank;
        this.suit = suit;
        this.skill = skill;
    }
}
