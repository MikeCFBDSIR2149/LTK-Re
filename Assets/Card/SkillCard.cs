using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCard : Card
{
    public SkillTyp skill;

    public SkillCard(Rank rank, Suit suit,SkillTyp skill) : base(rank, suit)
    {
        this.skill = skill;
    }

    //public override void Skill()
    //{
    //    base.Skill();

    //}
}

public enum SkillTyp
{
    BreakBridge,
    StealSheep,
    Creat,
    Duel,
    BorrowKnife,
    Swear,
    BumperHarvest,
    Intrusion,
    ArrowsShot,
    Invulnerable,
    FireAttack,
    IronChain,
    Le,
    NoFood,
    Lightning
}