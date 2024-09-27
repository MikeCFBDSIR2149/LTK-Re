using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//出牌阶段，对所有角色使用。每名目标角色回复1点体力。
public sealed class Swear : BaseSkill
{
    protected override void CardSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }
}
