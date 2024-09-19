using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//效果一
public class CriticalImpactEffect : IImpactEffect
{
    public void ApplyEffect(SkillDeployer deployer)
    {
        Console.WriteLine("skill02");
    }
}
