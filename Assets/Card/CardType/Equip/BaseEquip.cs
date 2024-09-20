using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEquip : BaseSkill
{
    public string Name;

    protected virtual void EquipSkill(FSMBase player, FSMBase target)
    {
        //...由子类重写,调用功能函数实现技能
    }
}
