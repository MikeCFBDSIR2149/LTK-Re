using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
//范围释放器（未完成）
public class SectorAttackSelecter : Iskill1
{
    public Transform[] SelectTarget(Skillstatus skill, Transform skillTF)
    {
        List<Transform> targets = new List<Transform>();
        foreach (string tag in skill.attackTargetTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag); ;
            Transform[] targetEnemies = enemies.Select(t => t.transform).ToArray();
            targets.AddRange(targetEnemies);
            
        }
        return targets.ToArray();

    }


}
