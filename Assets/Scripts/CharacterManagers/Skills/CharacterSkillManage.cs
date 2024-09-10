using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSkillManage : MonoBehaviour
{
    public Skillstatus[] skillstatus;

    public GeneralCamp generalCamp;

    private void Start()
    {
        for (int i = 0; i < skillstatus.Length; i++)
        {
            IntSkill(skillstatus[i]);
        }

        generalCamp = GetComponent<GeneralCamp>();
    }

    private void IntSkill(Skillstatus skill)
    {
        skill.skillPrefab = Resources.Load<GameObject>(skill.prefabName);
        skill.owner = gameObject;
    }
    //等待实现
    /*public SkillStatus PrepareSkill(int id)
    {
        //这里用了一个自己写的便于列表操作的静态方法
        SkillStatus skill = skillStatus.ArrayFind(s => s.skillID == id);
        if (skill != default(SkillStatus) && skill.coolRemain<=0&& skill.costSP <= characterBasic.characterSP)
        {
            return skill;
        }
        else
        {
            return null;
        }
    }*/
    /*public void GenerateSkill(SkillStatus skill)
    {
        //这里用了对象池，管理技能对象
        GameObject skillGo = GameObjectPool.Instance.CreateObject(skill.prefabName, skill.skillPrefab, transform.position, transform.rotation);
 
        //调用技能释放器释放技能
        SkillDeployer skillDeployer = skillGo.GetComponent<SkillDeployer>();
        skillDeployer.SkillStatus = skill;
        skillDeployer.DeployerSkill();
 
        //利用对象池回收技能对象
        GameObjectPool.Instance.CollectObject(skillGo,skill.durationTime);
        //技能冷却
        StartCoroutine(CoolTimeDown(skill));
    }*/

    
}
