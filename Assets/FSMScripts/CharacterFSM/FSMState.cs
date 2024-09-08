using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///状态类
    ///<summary>
    public abstract class FSMState
    {
        public FSMStateID StateID;
        private Dictionary<FSMTriggerID, FSMStateID> map;
        private List<FSMTrigger> Triggers;
        public abstract void Init();
        public FSMState()
        {
            Init();
            map = new Dictionary<FSMTriggerID, FSMStateID>();
            Triggers = new List<FSMTrigger>();
        }
        public void AddMap(FSMTriggerID triggerID, FSMStateID stateID)
        {
            map.Add(triggerID, stateID);
            Type type = Type.GetType("FSM." + triggerID.ToString() + "Trigger");
            FSMTrigger trigger = Activator.CreateInstance(type) as FSMTrigger;
            Triggers.Add(trigger);
        }
        public virtual void EnterState(FSMBase fsm) { }
        public virtual void ExitState(FSMBase fsm) { }
        public virtual void ActionState(FSMBase fsm) { }
        public void Reason(FSMBase fsm)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i].HandleTrigger(fsm))
                {
                    FSMStateID stateID = map[Triggers[i].TriggerID];
                    fsm.ChangeActiveState(stateID);
                    //切换状态
                    return;
                }
            }
        }
    }
}
