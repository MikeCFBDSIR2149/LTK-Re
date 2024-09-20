using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeployerConfigFactory 
{
    public static IImpactEffect CreateIImpactEffect(Skillstatus skillStatus)
    {
        // 根据技能状态或其他参数决定具体实现
        // 这里的实现只是一个示例
        if (skillStatus.IsCritical)
        { 
            return new CriticalImpactEffect();
        }
        else
        {
            return new StandardImpactEffect();
        }
    }
}
