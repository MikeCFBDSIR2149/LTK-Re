using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    ///<summary>
    ///
    ///<summary>
    public enum FSMStateID
    {
        Start,//开局
        Wait,//等待其他玩家操作
        BeChosen,//被选择
        TrueDead,//死亡
        BeforeDead,//濒死
        ReceiveCards,//发牌
        PlayCards,//出牌
        AbandonCards//弃牌
    }

    public enum FSMTriggerID
    {
        NoHealth,//生命为0
        GetSaved,//被救了
        NoSave,//没有人救
        ToBeChosen,//被选择
        GameStart,//游戏开始
        AfterStart,//开局之后
        Action,//玩家行动
        FinishReceive,//结束发牌
        FinishPlay,//结束出牌
        FinishAbandon,//结束弃牌
        FinishBeChosen//结束被选择
    }
}
