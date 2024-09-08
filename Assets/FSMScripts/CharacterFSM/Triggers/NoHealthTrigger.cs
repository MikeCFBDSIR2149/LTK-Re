
namespace FSM
{
    ///<summary>
    ///没有生命条件
    ///<summary>
    public class NoHealthTrigger : FSMTrigger
    { 
        public override bool HandleTrigger(FSMBase fsm)
        { 
            return fsm.bridge.playerCurrentHealth <=0;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }
    }
}
