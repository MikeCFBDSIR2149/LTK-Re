using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///判定阶段
    ///<summary>
    public class JudgeState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Judge;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}
