using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///结束出牌条件
    ///<summary>
    public class FinishPlayTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.playOver;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishPlay;
        }
    }
}
