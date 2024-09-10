using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public string Name;
    public Rank rank;
    public Suit suit;

    //传入参数：出牌人,出牌对象
    protected virtual void CardSkill(/*...*/)
    {
        //调用具体功能方法...
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
