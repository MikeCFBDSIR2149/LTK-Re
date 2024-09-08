using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Analytics;
//示例1：张角
public class Character : GeneralCamp
{
   public Iskill1 skill;
   
   public void Start()
   {
      Gender = 1;
      Name = "张角";
      Type = CampType.Wu;
      Camp();
      print("YU");
      

   }
   public override void Skill()
   {
      // 实现技能逻辑
      skill = GetComponent<Iskill1>();
      skill.Skill1();
   }

   

}

