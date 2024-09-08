using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///begin judging trigger
    ///<summary>
    public class BeginJudgeTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.judgePermisson;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.BeginJudge;
        }
    }
}
