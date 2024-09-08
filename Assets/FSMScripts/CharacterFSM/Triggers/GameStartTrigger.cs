using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///游戏开始条件
    ///<summary>
    public class GameStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return CharacterFSMController.Instance.currentRound == RoundState.Start;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.GameStart;
        }
    }
}
