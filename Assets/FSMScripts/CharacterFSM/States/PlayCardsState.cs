using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///出牌阶段
    ///<summary>
    public class PlayCardsState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.PlayCards;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}

