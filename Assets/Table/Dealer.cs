using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public Deck Deck;

    int cardIdx = 0;    //牌库索引
    int playerIdx = 0;  //回合索引

    public int dealtimes = 2;  //抽牌次数

    public GameObject cardPrfab;    //卡牌预制件

    public List<GameObject> playersList = new List<GameObject>();   //玩家列表

    private void Update()
    {
        //按空格下一回合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextRound();
        }
    }

    /// <summary>
    /// 抽牌
    /// </summary>
    /// <param name="target">发牌对象</param>
    /// <param name="times">发牌次数</param>
    private void DealCard(GameObject target, int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (cardIdx == Deck.deck.Count)
            {
                Deck.Shuffle();
                cardIdx = 0;
            }   //牌库为零时重新洗牌

            var card = Instantiate(cardPrfab, target.transform);    //生成预制件
            var next = Deck.deck[cardIdx];      //获得下张牌数据
            Deck.AddSkillToCard(card, next);    //绑定数据与物体
            target.GetComponent<PlayerBasic>().cardFactory.AddCard(next.cardType, next.skill.Name, card);   //添加到目标手牌中
            cardIdx++;      //索引后移
        }
        Debug.Log("发牌完毕");
    }

    /// <summary>
    /// 回合轮次
    /// </summary>
    private void NextRound()
    {
        if (playerIdx == playersList.Count) { playerIdx = 0; }      //回合重跑

        Debug.Log("玩家" + playersList[playerIdx] + "回合");
        DealCard(playersList[playerIdx], dealtimes);
        playerIdx++;
    }
}
