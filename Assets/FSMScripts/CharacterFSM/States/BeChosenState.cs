using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///被选择阶段
    ///<summary>
    public class BeChosenState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.BeChosen;
        }
        public override void EnterState(FSMBase fsm)
        { }
        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.bridge.isBeChosen = false;
            fsm.bridge.chosenOver = false;
        }
    }
}

