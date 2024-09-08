using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///开局之后条件
    ///<summary>
    public class AfterStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return CharacterFSMController.Instance.currentRound != RoundState.Start;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.AfterStart;
        }
    }
}