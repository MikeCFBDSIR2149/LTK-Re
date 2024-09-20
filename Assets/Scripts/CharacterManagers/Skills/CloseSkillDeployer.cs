using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSkillDeployer : SkillDeployer
{

    public override void DeployerSkill()
    {
        //CalculateTargets();
        SkillStatus.prefabName = "Prefab1";
        ImpactTargets();
        Debug.Log("Skill1");
    }

}
