using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///弃牌阶段
    ///<summary>
    public class AbandonCardsState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.AbandonCards;
        }
        public override void EnterState(FSMBase fsm)
        { }
        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            CharacterFSMController.Instance.characterAction[fsm.bridge.playerID] = true;
        }
    }
}

