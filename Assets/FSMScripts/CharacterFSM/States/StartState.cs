using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///开始游戏阶段
    ///<summary>
    public class StartState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Start;
        }
        public override void EnterState(FSMBase fsm)
        {
           
        }
    }
}
