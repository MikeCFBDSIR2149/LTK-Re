using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EquipSO")]
public class EquipSO : SkillSO
{
    public List<string> equipments = new List<string>();

    public List<bool> isNextSame = new List<bool>();
}
