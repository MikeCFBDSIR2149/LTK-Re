using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///结束弃牌条件
    ///<summary>
    public class FinishBeChosenTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.chosenOver;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishBeChosen;
        }
    }
}
