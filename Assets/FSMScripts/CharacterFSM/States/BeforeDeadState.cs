using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///�����׶�
    ///<summary>
    public class BeforeDeadState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.BeforeDead;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}

