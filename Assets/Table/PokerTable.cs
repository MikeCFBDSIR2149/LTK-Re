using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PokerTable : MonoBehaviour
{
    public Stack<BaseSkill> table = new Stack<BaseSkill>();

    public BaseSkill pushCard { set => table.Push(value); }     //出牌时调用

    //结束阶段时调用
    public void Calculator()
    {
        if (table.Count == 0) return;

        
    }
}
