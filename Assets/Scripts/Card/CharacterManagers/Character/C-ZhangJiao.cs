using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Analytics;
//示例1：张角
public class ZhangJiao: GeneralCamp
{
   private GetSkill skill;
   
   public void Start()
   {
      Gender = 1;
      ExtraName = "特别之人";
      Name = "张角";
      Type = CampType.Wu;
      MaxHp = 4;
      Hp = MaxHp;
      NowHp = MaxHp;
      Camp();
      print(ExtraName+" "+Name);
      print("HP="+Hp);
      skill = GetComponent<GetSkill>();

   }
   private void Update()
   { 
      SkillManager();
      Current();
   }
   public override void SkillManager()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           // 当按下空格键时，调用方法
           // 实现1技能逻辑
           skill.NorSkill1();
          
       }
       if (Input.GetKeyDown(KeyCode.E))
       {
           // 当按下E键时，调用方法
           // 实现2技能逻辑
           skill.SpecialSkill();
          
       }
       
   }
   
}

