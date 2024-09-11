using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Analytics;
//示例1：张角
public class ZhangJiao: GeneralCamp
{
   private ZSkill1 skill1;  
   private ZSkill2 skill2;


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
      skill1 = GetComponent<ZSkill1>();
      skill2 = GetComponent<ZSkill2>();

   }
   private void Update()
   { 
      Current();
   }

   public void OnGUI()
   {
       if (GUI.RepeatButton(new Rect(25, 25, 100, 30), "RepeatButton"))
       {
           StartCoroutine(skill1.NorSkill1());
       }

   }

   public override void SkillManager()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           // 当按下空格键时，调用方法
           // 实现1技能逻辑
           skill1.NorSkill1();
          Console.WriteLine();
       }
       if (Input.GetKeyDown(KeyCode.E))
       {
           // 当按下E键时，调用方法
           // 实现2技能逻辑
           skill2.SpecialSkill();
           Console.WriteLine();
       }
       
   }
   
}

