using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCard : Card
{
    public int distance;

    public EquipCard(Rank rank, Suit suit,int distance) : base(rank, suit)
    {
        this.distance = distance;
    }
}
