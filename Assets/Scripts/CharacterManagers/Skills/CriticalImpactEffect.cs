using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//效果一
public class CriticalImpactEffect : IImpactEffect
{
    public void ApplyEffect(SkillDeployer deployer)
    {
        var status =deployer.SkillStatus.owner.GetComponent<GeneralCamp>();
        Console.WriteLine("skill02");
        Debug.Log("GOOD");
        status.Hp--;
    }
}
