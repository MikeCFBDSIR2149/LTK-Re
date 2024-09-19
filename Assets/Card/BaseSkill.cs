using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public SkillType type;
    public Rank rank;
    public Suit suit;

    protected BaseSkill GetSkillType()
    {
        return this;
    }

    //传入参数：出牌人,出牌对象
    protected virtual void CardSkill(/*...*/)
    {
        //...由子类重写,调用功能函数实现技能
    }

    protected void MinusBlood(/*...*/)
    {

    }

    protected void AddBlood(/*...*/)
    {

    }

    protected void GetCard(/*...*/)
    {

    }
    
}
