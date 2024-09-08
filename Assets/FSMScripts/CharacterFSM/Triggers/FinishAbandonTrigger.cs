using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///结束弃牌条件
    ///<summary>
    public class FinishAbandonTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            CommunicationBridge comBridge = fsm.bridge;
            return comBridge.abandonCardsPermisson || comBridge.playerCurrentHealth >= comBridge.playerCardsNum;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishAbandon;
        }
    }
}
