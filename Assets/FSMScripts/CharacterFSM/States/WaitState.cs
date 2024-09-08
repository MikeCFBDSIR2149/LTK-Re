using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///等待其他玩家出牌阶段
    ///<summary>
    public class WaitState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Wait;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}
