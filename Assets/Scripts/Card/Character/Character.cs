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
   public GetSkill skill;
   
   public void Start()
   {
      Gender = 1;
      Name = "张角";
      Type = CampType.Wu;
      MaxHp = 4;
      Hp = MaxHp;
      NowHp = MaxHp;
      Camp();
      print("HP="+Hp);
      skill = GetComponent<GetSkill>();

   }
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         // 当按下空格键时，调用方法
         
         Skill();
      }
      Current();
   }
   public override void Skill()
   {
      // 实现技能逻辑
      skill.Skill1();
   }

   

}

