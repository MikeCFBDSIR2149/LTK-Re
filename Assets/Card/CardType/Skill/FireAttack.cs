using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//出牌阶段，对一名有手牌的角色使用。该角色展示一张手牌，然后若你弃置与之花色相同的一张手牌，则你对其造成1点火焰伤害。
public sealed class FireAttack : BaseSkill
{
    protected override void CardSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }

}
