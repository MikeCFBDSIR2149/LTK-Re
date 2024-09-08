using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///������������
    ///<summary>
    public class FinishAbandonTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return false;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishAbandon;
        }
    }
}
