using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///���ƽ׶�
    ///<summary>
    public class ReceiveCardsState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.ReceiveCards;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}

