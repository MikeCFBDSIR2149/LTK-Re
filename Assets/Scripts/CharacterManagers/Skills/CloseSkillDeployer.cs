using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSkillDeployer : SkillDeployer
{

    public override void DeployerSkill()
    {
        //CalculateTargets();
        ImpactTargets();
        Debug.Log("Skill1");
    }

}
