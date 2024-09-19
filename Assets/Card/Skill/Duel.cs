using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;

//出牌阶段，对一名其他角色使用。由该角色开始，你与其轮流打出一张【杀】，然后首先未打出【杀】的角色受到另一名角色造成的1点伤害。
public class Duel : BaseSkill
{
    void SkillExucute() 
    {
       // EventCenter.Instance.AddEventListener(E_EventType.Duel,Test);
        
    }
    private void OnDisable()
    {
       // EventCenter.Instance.RemoveEventListener(E_EventType.Duel,Test);
    }
    void Test() 
    {
       // EventCenter.Instance.EventTrigger(E_EventType.Duel);
    }
}
