using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCard : Card
{
    public Typ typ;

    public BasicCard(Rank rank, Suit suit,Typ Typ) : base(rank, suit)
    {
        this.typ = Typ;
    }

    //��Ҫ�������
    //public override void Skill()
    //{
    //    base.Skill();

    //}
}

public enum Typ
{
    Kill,
    Dodge,
    Life
}
