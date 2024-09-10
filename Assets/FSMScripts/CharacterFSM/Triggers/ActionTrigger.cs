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
    ///<summary>
    ///玩家行动条件
    ///<summary>
    public class ActionTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.actionPermission;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Action;
        }
    }
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
    ///<summary>
    ///结束发牌条件
    ///<summary>
    public class FinishReceiveTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.receiveOver;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.FinishReceive;
        }
    }
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
    ///<summary>
    ///有人救条件
    ///<summary>
    public class GetSavedTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.isGetSaved;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.GetSaved;
        }
    }
    ///<summary>
    ///没有生命条件
    ///<summary>
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.playerCurrentHealth <= 0;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }
    }
    ///<summary>
    ///没有人救条件
    ///<summary>
    public class NoSaveTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return !fsm.bridge.isGetSaved;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoSave;
        }
    }
    ///<summary>
    ///玩家被选择条件
    ///<summary>
    public class ToBeChosenTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.bridge.isBeChosen;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.ToBeChosen;
        }
    }
}
