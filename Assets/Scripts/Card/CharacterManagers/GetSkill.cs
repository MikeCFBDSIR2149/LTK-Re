using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//接口实现
public class GetSkill : MonoBehaviour,Iskill1
{
    public ZhangJiao generalCamp=new ZhangJiao();
    public void NorSkill1()
    {
        generalCamp.NowHp--;
        print("NowHp="+generalCamp.NowHp);
    }

    public void SpecialSkill()
    {
        generalCamp.NowHp++;
        print("NowHp=" + generalCamp.NowHp);
    }
}
