using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
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
    protected CampType Type { get; set; }
    public int MaxHp { get; set; }

    public int Hp { get; set; }
    public int NowHp { get; set; }
    
    
}
//角色阵营分配以及阵营相关
public class GeneralCamp:PeopleBase
{
    
    private delegate void GeneralDelegate();

    private GeneralDelegate wuDelegate;
    private GeneralDelegate suDelegate;
    private GeneralDelegate weiDelegate;

    
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
        wuDelegate = Wu;
        suDelegate = Su;
        weiDelegate = Wei;
        switch (Type)
        {
            case CampType.Wu:
                wuDelegate.Invoke();
                break;
            case CampType.Su:
                suDelegate.Invoke();
                break;
            case CampType.Wei:
                weiDelegate.Invoke();
                break;
            default:
                Debug.LogError("Unknown CampType");
                break;
        }
    }
    
    public virtual void Skill()
    {
        // 实现技能逻辑
        
    }

    public void Current()
    {
        
        int currentHp = Hp;
        if (currentHp != NowHp)
        {
            Hp = NowHp;
            print("Hp="+Hp);
        }
    }   
}
    
