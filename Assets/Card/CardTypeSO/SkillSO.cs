using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SkillSO")]
public class SkillSO : ScriptableObject 
{
    public SkillType type;
    public List<Rank> ranks;
    public List<Suit> suits;
}
