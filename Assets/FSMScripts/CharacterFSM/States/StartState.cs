using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///��ʼ��Ϸ�׶�
    ///<summary>
    public class StartState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Start;
        }
        public override void EnterState(FSMBase fsm)
        {
           
        }
    }
}
