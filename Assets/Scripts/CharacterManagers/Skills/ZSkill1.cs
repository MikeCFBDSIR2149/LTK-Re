using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSkill1 : Skillstatus
{
    
    public ZhangJiao generalCamp=new ZhangJiao();

    public void Start()
    {
        skillName = "诡计";
        skillDescription = "待定";
        attackDistance = 2;

    }
    //迭代器测试
    public IEnumerator NorSkill1()
    {
        if (generalCamp.NowHp > 0)
        {
            generalCamp.NowHp--;
            yield return new WaitForSeconds(1);
            Console.WriteLine("NowHp="+generalCamp.NowHp+skillName);
        }
        else
        {
            Console.WriteLine("DEAD");
        }
        
    }

 
}
