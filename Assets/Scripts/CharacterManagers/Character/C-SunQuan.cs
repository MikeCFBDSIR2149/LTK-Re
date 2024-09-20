using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunQuan :  GeneralCamp
{
    private CharacterSkillManage characterSkillManage;
    
       private void Awake()
       {
           Gender = 2;
           ExtraName = "江东帝王";
           Name = "孙权";
           Type = CampType.Wu;
           MaxHp = 3;
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
          SkillManager();
       }
    
       
    
       public override void SkillManager()
       {
           if (Input.GetKeyDown(KeyCode.Q))
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
    
           if (Input.GetKeyDown(KeyCode.E))
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
       
}

