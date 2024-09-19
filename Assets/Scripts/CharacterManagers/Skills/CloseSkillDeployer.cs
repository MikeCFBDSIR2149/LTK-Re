using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSkillDeployer : SkillDeployer
{
    public Skillstatus skillstatus;

    public void Start()
    {

        skillstatus.coolTime = 0;
        skillstatus.cost = 2;
    }

    public override void DeployerSkill()
    {
        //CalculateTargets();
        ImpactTargets();
        Debug.Log("Skill1");
    }

}
