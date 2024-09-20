using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
    public enum RoundState
    {
        Start,
        Play,
        End
    }

    public class CharacterFSMController : MonoSingleton<CharacterFSMController>
    {
        [HideInInspector]
        public Dictionary<int, FSMBase> characterFSMs = new Dictionary<int, FSMBase>();//key:玩家ID，value：玩家状态机
        private int idsIndex=0;
        private int roundValue;
        [HideInInspector]
        public int round
        {
            get
            {
                return roundValue;
            }
            set
            {
                foreach (var id in characterAction.Keys)
                {
                    characterAction[id] = false;
                }
                foreach (var player in PlayersManager.Instance.players.Values)
                {
                    if (player.seatNum==1)
                    {
                        characterFSMs[player.playerID].bridge.actionPermission = true;
                    }
                }
            }
        }
        [HideInInspector]
        public Dictionary<int, bool> characterAction = new Dictionary<int, bool>();

        private RoundState currentRoundValue;
        [HideInInspector]
        public RoundState currentRound
        {
            get
            {
                return currentRoundValue;
            }
            set
            {
                currentRoundValue = value;
                if (value == RoundState.Start)
                {
                    StartGame();
                }
                else if (value == RoundState.End)
                {
                    EndGame();
                }
            }
        }
        public override void Init()
        {
            base.Init();
        }
        private void Start()
        {
            round = 1;
            currentRound = RoundState.Start;
        }
        private void StartGame()
        {
            foreach (var character in characterFSMs.Values)
            {
                character.bridge.InitPermission();
            }
        }
        private void EndGame()
        {

        }
        private void Update()
        {
            if(GotoNextRound())
                round++;
        }

        private bool GotoNextRound()
        {
            foreach (bool flag in characterAction.Values)
            {
                if (!flag)
                    return false;
            }
            return true;
        }
    }
}
