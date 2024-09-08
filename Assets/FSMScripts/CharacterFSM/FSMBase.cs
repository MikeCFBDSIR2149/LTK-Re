using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///
    ///<summary>
    public class FSMBase : MonoBehaviour
    {
        private List<FSMState> states;
        private FSMStateID defaultStateID = FSMStateID.Wait;
        private FSMState currentState;
        private FSMState defaultState;

        #region 查找数据
        public CommunicationBridge bridge;
        private void InitComponent()
        {
            CharacterFSMController.Instance.characterFSMs.Add(bridge.playerID, this);//添加状态机
        }
        #endregion

        private void Start()
        {
            InitComponent();
            ConfigFSM();
            InitDefualtState();
        }
        private void ConfigFSM()
        {
            states = new List<FSMState>();
            StartState start = new StartState();
            states.Add(start);
            start.AddMap(FSMTriggerID.AfterStart, FSMStateID.Wait);
            WaitState wait = new WaitState();
            states.Add(wait);
            wait.AddMap(FSMTriggerID.Action, FSMStateID.ReceiveCards);
            wait.AddMap(FSMTriggerID.GameStart, FSMStateID.Start);
            BeChosenState beChosen = new BeChosenState();
            states.Add(beChosen);
            beChosen.AddMap(FSMTriggerID.FinishBeChosen, FSMStateID.Wait);
            TrueDeadState trueDead = new TrueDeadState();
            states.Add(trueDead);
            BeforeDeadState beforeDead = new BeforeDeadState();
            states.Add(beforeDead);
            beforeDead.AddMap(FSMTriggerID.NoSave, FSMStateID.TrueDead);
            beforeDead.AddMap(FSMTriggerID.GetSaved, FSMStateID.Wait);
            ReceiveCardsState receiveCards = new ReceiveCardsState();
            states.Add(receiveCards);
            receiveCards.AddMap(FSMTriggerID.FinishReceive, FSMStateID.PlayCards);
            PlayCardsState playCards = new PlayCardsState();
            states.Add(playCards);
            playCards.AddMap(FSMTriggerID.FinishPlay, FSMStateID.AbandonCards);
            AbandonCardsState abandonCards = new AbandonCardsState();
            states.Add(abandonCards);
            abandonCards.AddMap(FSMTriggerID.FinishAbandon, FSMStateID.Wait);
            JudgeState judge = new JudgeState();
            states.Add(judge);
            judge.AddMap(FSMTriggerID.FinishJudge, FSMStateID.Wait);
            foreach (FSMState state in states)
            {
                state.AddMap(FSMTriggerID.NoHealth, FSMStateID.BeforeDead);
                state.AddMap(FSMTriggerID.BeginJudge,FSMStateID.Judge);
            }
        }
        private void InitDefualtState()
        {
            defaultState = states.Find(s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);
        }
        public void Update()
        {
            currentState.Reason(this);//检测
            currentState.ActionState(this);
        }
        public void ChangeActiveState(FSMStateID stateID)
        {
            currentState.ExitState(this);
            currentState = states.Find(s => s.StateID == stateID);
            currentState.EnterState(this);
        }
    }
}
