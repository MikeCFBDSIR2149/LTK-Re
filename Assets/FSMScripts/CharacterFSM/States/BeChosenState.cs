using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///±»Ñ¡Ôñ½×¶Î
    ///<summary>
    public class BeChosenState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.BeChosen;
        }
        public override void EnterState(FSMBase fsm)
        { }
    }
}

