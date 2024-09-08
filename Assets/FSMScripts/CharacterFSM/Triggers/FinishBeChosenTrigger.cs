using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///½áÊøÆúÅÆÌõ¼þ
    ///<summary>
    public class FinishBeChosenTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return false;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishBeChosen;
        }
    }
}
