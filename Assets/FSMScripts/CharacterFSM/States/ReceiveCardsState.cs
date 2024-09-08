using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///发牌阶段
    ///<summary>
    public class ReceiveCardsState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.ReceiveCards;
        }
        public override void EnterState(FSMBase fsm)
        { }
        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.bridge.receiveOver = false;
        }
    }
}

