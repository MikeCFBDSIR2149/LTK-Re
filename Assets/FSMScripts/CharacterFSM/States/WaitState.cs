using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///�ȴ�������ҳ��ƽ׶�
    ///<summary>
    public class WaitState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Wait;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}
