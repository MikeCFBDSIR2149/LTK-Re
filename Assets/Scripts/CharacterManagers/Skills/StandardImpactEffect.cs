using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//效果二
public class StandardImpactEffect : IImpactEffect
{
    public void ApplyEffect(SkillDeployer deployer)
    {
        Console.WriteLine("skill01");
    }
}
