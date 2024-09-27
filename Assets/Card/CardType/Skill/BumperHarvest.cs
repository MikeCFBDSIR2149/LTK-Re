using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//出牌阶段，对所有角色使用。你亮出牌堆顶等同于目标角色数的牌。每名目标角色获得其中的一张。
public sealed class BumperHarvest : BaseSkill
{
    protected override void CardSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }

}
