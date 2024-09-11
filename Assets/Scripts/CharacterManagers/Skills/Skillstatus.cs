using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Skillstatus :MonoBehaviour
{
    //技能ID
    public int skillID;

    //技能名称
    public string skillName;
    //技能描述
    public string skillDescription;
    //技能攻击距离
    public float attackDistance;
    //技能消耗
    public float cost;

    //攻击目标
    public string[] attackTargetTags = { "Enemy" };

    //技能攻击对象
    [HideInInspector]
    public Transform[] attackTargets;
    //技能所属
    public GameObject owner;

    //技能预制件名字
    public string prefabName;

    [HideInInspector]
    //预制件对象
    public GameObject skillPrefab;
    //动画名称
    public string animationName;
    //受到攻击的特效名字
    public string hitFxName;
    //技能分类判断
    public bool IsCritical;

}
