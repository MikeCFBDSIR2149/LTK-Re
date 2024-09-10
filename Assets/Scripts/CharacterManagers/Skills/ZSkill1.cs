using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//接口实现
public class ZSkill1 : Skillstatus
{
    
    public ZhangJiao generalCamp=new ZhangJiao();

    public void Start()
    {
        skillName = "诡计";
        skillDescription = "待定";
        attackDistance = 2;

    }

    public void NorSkill1()
    {
        
        generalCamp.NowHp--;
        Console.WriteLine("NowHp="+generalCamp.NowHp+skillName);
    }

 
}
