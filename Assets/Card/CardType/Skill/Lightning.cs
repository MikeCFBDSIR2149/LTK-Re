using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//出牌阶段，对你使用。将【闪电】置入你的判定区。若判定结果为♠2-9，则目标角色受到3点雷电伤害。若判定不为此结果，将之置入其下家的判定区。
public class Lightning : BaseSkill
{
    protected override void CardSkill(FSMBase player, FSMBase target)
    {
        //...重写父类,调用功能函数实现技能
    }

}
