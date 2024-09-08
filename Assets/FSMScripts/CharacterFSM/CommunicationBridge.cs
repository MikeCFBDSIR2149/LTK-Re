using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CommunicationBridge
{
    public int playerID;//玩家ID
    [HideInInspector]
    public  bool actionPermission = false;//该玩家是否可以开始回合
    [HideInInspector]
    public bool judgePermisson=false;//是否进行判定
    [HideInInspector]
    public bool receiveCardsPermisson = false;//是否可以发牌
    [HideInInspector]
    public bool playCardsPermisson =false;//是否可以出牌
    [HideInInspector]
    public bool abandonCardsPermisson = false;//是否可以直接跳过弃牌阶段
    [HideInInspector]
    public bool isBeChosen = false;//是否被选中
    [HideInInspector]
    public bool chosenOver = false;
    [HideInInspector]
    public bool judgeOver=false;//判定是否结束
    [HideInInspector]
    public bool playOver;//玩家是否结束出牌
    [HideInInspector]
    public bool receiveOver;//是否结束发牌
    [HideInInspector]
    public bool isGetSaved;//是否被救
    [HideInInspector]
    public int playerCurrentHealth;//玩家生命点数
    [HideInInspector]
    public int playerCardsNum;//玩家手牌数
    public void InitPermission(string[] onlyInit = null)
    {
        //只初始化某几个属性
        if (onlyInit != null)
        {
            for (int i = 0; i < onlyInit.Length; i++)
            {
                switch (onlyInit[i])
                {
                    case "action":
                        actionPermission = false ; break;
                    case "judge":
                        judgePermisson = false ; break;
                    case "receive":
                        receiveCardsPermisson = false ; break;
                    case "playCards":
                        playCardsPermisson = false ; break;
                    case "abandonCards":
                        abandonCardsPermisson = false ; break;
                }
            }
            return;
        }
        actionPermission = false;
        judgePermisson = false;
        receiveCardsPermisson = false;
        playCardsPermisson = false;
        abandonCardsPermisson = false;
    }
}
