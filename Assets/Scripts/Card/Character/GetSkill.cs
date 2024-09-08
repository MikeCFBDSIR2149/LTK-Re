using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//接口实现
public class GetSkill : MonoBehaviour,Iskill1
{
    public GeneralCamp generalCamp=new GeneralCamp();
    public void Skill1()
    {
        generalCamp.NowHp--;
        print("NowHp="+generalCamp.NowHp);
    }
}
