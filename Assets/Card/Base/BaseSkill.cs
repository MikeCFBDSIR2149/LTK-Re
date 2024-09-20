using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public abstract class BaseSkill : MonoBehaviour
{
    public CardType cardType;
    public SkillType skillType;
    public Rank rank;
    public Suit suit;

    protected BaseSkill GetSkillType()
    {
        return this;
    }

    private bool DistanceCalculate(int player, int target) => player >= target;


    //传入参数：出牌人,出牌对象
    protected virtual void CardSkill(FSMBase player, FSMBase target)
    {
        //...由子类重写,调用功能函数实现技能
    }

    protected void MinusBlood(FSMBase target, int minusNum)
    {
        target.bridge.playerCurrentHealth -= minusNum;
    }

    protected void AddBlood(FSMBase target, int addNum)
    {
        target.bridge.playerCurrentHealth += addNum;
    }

    protected void GetCard(FSMBase target)
    {
        target.bridge.receiveCardsPermisson = true;
    }
    
}
