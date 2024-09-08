using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//角色阵营
public enum CampType
{
    Wu,
    Su,
    Wei,
}
//角色属性
public abstract class PeopleBase:MonoBehaviour
{
    public int Gender { get; set; }
    public string Name { get; set; }
    public CampType Type { get; set; }
    
    public abstract void Skill();
}
//角色阵营分配以及阵营相关
public class GeneralCamp:PeopleBase
{
    public delegate void GeneralDelegate();

    public GeneralDelegate WuDelegate;
    public GeneralDelegate SuDelegate;
    public GeneralDelegate WeiDelegate;

  

    public void Wu()
    {
        print("吴");
    }

    public void Su()
    {
        print("蜀");
    }

    public void Wei()
    {
        print("魏");
    }
//利用委托实现阵营相关
    public void Camp()
    {
        WuDelegate = Wu;
        SuDelegate = Su;
        WeiDelegate = Wei;
        switch (Type)
        {
            case CampType.Wu:
                WuDelegate.Invoke();
                break;
            case CampType.Su:
                SuDelegate.Invoke();
                break;
            case CampType.Wei:
                WeiDelegate.Invoke();
                break;
            default:
                Debug.LogError("Unknown CampType");
                break;
        }
    }
    
    public override void Skill()
    {
        // 实现技能逻辑
        
    }
}
    
