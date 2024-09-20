using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSkillDeployer :  SkillDeployer
{

    public override void DeployerSkill()
    {
        //CalculateTargets();
        SkillStatus.prefabName = "Prefab2";
        ImpactTargets();
        Debug.Log("Skill2");
    }
}
