
using System;
using UnityEngine;
using UnityEngine.Analytics;
//示例1：张角
public class ZhangJiao: GeneralCamp
{
   private CharacterSkillManage characterSkillManage;

   private void Awake()
   {
       Gender = 1;
       ExtraName = "特别之人";
       Name = "张角";
       Type = CampType.Wu;
       MaxHp = 4;
       NowHp = MaxHp;
   }

   public void Start()
   {
      
      Camp();
      print(ExtraName+" "+Name);
      print("HP="+Hp);
      characterSkillManage = GetComponent<CharacterSkillManage>();
      
   }
   private void Update()
   { 
      Current();
      
   }

   public void OnGUI()
   {
       
       if (GUI.RepeatButton(new Rect(25, 25, 100, 30), "RepeatButton"))
       {
           
           Skillstatus skill = characterSkillManage.PrepareSkill(0);
          
           if (skill != null)
           {
               characterSkillManage.GenerateSkill(skill);
           }
           else
           {
               Debug.Log("技能无法释放：检查冷却或法力值。");
           }
       }
       if (GUI.RepeatButton(new Rect(25, 100, 100, 30), "Button"))
       {
           
           Skillstatus skill = characterSkillManage.PrepareSkill(1);
          
           if (skill != null)
           {
               characterSkillManage.GenerateSkill(skill);
           }
           else
           {
               Debug.Log("技能无法释放：检查冷却或法力值。");
           }
       }

   }

   public override void SkillManager()
   {
   }
   
}

