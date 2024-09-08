using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCard : Card
{
    public BaseSkill skill;

    public SkillCard(Rank rank, Suit suit, BaseSkill typ) : base(rank, suit)
    {
        this.skill = typ;
    }

    //public override void Skill()
    //{
    //    base.Skill();

    //}
}

//public enum SkillTyp
//{
//    BreakBridge,
//    StealSheep,
//    Creat,
//    Duel,
//    BorrowKnife,
//    Swear,
//    BumperHarvest,
//    Intrusion,
//    ArrowsShot,
//    Invulnerable,
//    FireAttack,
//    IronChain,
//    Le,
//    NoFood,
//    Lightning
//}