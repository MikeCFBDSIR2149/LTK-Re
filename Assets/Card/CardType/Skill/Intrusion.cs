using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//出牌阶段，对所有其他角色使用。每名目标角色需打出一张【杀】，否则受到你造成的1点伤害。
public sealed class Intrusion : BaseSkill
{
    protected override void CardSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }

}
