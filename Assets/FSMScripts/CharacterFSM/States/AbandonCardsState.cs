using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///���ƽ׶�
    ///<summary>
    public class AbandonCardsState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.AbandonCards;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}

