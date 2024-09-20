using FSM;
using UnityEngine;
[RequireComponent(typeof(FSMBase))]
public class PlayerBasic : MonoBehaviour
{
    private FSMBase characterFSMBase;
    private CommunicationBridge characterBridge;


    public int playerID;//玩家编号
    public int seatNum;//第几号位

    [HideInInspector]
    public int cardsNumber
    {
        get
        {
            return cardsNumValue;
        }
        set
        {
            cardsNumValue = value;
            characterBridge.playerCardsNum = value;
        }
    }
    private int cardsNumValue;

    [HideInInspector]
    public int distancePlus;
    [HideInInspector]
    public int distanceMinus;
    
    private void Awake()
    {
        characterFSMBase = GetComponent<FSMBase>();
        characterBridge = characterFSMBase.bridge;
        characterBridge.playerID = playerID;
        PlayersManager.Instance.players.Add(playerID,this);
        distancePlus = 0;
        distanceMinus = 0;
    }
}
