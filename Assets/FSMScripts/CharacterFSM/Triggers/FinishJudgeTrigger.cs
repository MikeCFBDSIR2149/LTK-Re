using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///finish judging trigger
    ///<summary>
    public class FinishJudgeTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.judgeOver;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishJudge;
        }
    }
}
