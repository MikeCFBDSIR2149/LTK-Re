using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///û���˾�����
    ///<summary>
    public class NoSaveTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return false;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoSave;
        }
    }
}
