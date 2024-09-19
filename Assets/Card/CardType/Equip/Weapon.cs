using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : BaseEquip
{
    public int distance;

    protected override void EquipSkill(/*...*/)
    {
        //...重写父类,调用功能函数实现技能
    }
}
