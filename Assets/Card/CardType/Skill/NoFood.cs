using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//出牌阶段，对距离为1的一名其他角色使用。将【兵粮寸断】置入该角色的判定区，若判定结果不为♣，则其跳过摸牌阶段。
public sealed class NoFood : BaseSkill
{
    protected override void CardSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }

}
