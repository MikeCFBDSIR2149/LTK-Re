using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Horse : BaseEquip
{
    protected int distance;

    protected override void EquipSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }
}
