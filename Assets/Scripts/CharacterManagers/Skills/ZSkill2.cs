using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSkill2 : Skillstatus
{
    public ZhangJiao generalCamp=new ZhangJiao();
    // Start is called before the first frame update
    void Start()
    {
        skillName = "诡计1";
        skillDescription = "待定2";
        attackDistance = 3;
    }

    // Update is called once per frame
    public void SpecialSkill()
    {
        
        generalCamp.NowHp++;
        Console.WriteLine("NowHp=" + generalCamp.NowHp+skillName);
    }
}
