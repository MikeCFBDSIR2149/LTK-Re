using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillDeployer : MonoBehaviour
{
    //用于接收技能数据
    private Skillstatus skillStatus;
    //接收到技能数据后立刻初始化
    public Skillstatus SkillStatus
    {
        get
        {
            return skillStatus;
        }
        set
        {
            skillStatus = value;
            InitDeployer();
        }
    }
    //用于存放攻击范围和技能效果的接口
    //private IAttackSelector selector;
    private IImpactEffect impactArray;

    //初始化
    private void InitDeployer()
    {
        //通过工厂类的方法根据技能数据，生成对应脚本放入接口的变量内
        //selector = DeployerConfigFactory.CreateIAttackSelector(skillStatus);
        impactArray = DeployerConfigFactory.CreateIImpactEffect(skillStatus);
    }
 
    //调用范围选择的接口方法进行选择，将对象存入skillStatus中
    /*public void CalculateTargets()
    {
        skillStatus.attackTargets = selector.SelectTarget(skillStatus, transform);
    }*/
 
    //效果释放
    public void ImpactTargets()
    {
        impactArray.ApplyEffect();
    }
    public abstract void DeployerSkill();

}
