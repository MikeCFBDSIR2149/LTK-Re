using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public SkillSO[] skills;
    public Dictionary<SkillSO,Type> skilldic = new Dictionary<SkillSO,Type>();

    private void Awake()
    {
        skilldic.Add(skills[0], typeof(ArrowsShot));
        skilldic.Add(skills[1], typeof(BorrowKnife));
        skilldic.Add(skills[2], typeof(BreakBridge));
        skilldic.Add(skills[3], typeof(BumperHarvest));
        skilldic.Add(skills[4], typeof(Creat));
        skilldic.Add(skills[5], typeof(Duel));
        skilldic.Add(skills[6], typeof(FireAttack));
        skilldic.Add(skills[7], typeof(Intrusion));
        skilldic.Add(skills[8], typeof(Invulnerable));
        skilldic.Add(skills[9], typeof(IronChain));
        skilldic.Add(skills[10], typeof(Le));
        skilldic.Add(skills[11], typeof(Lightning));
        skilldic.Add(skills[12], typeof(NoFood));
        skilldic.Add(skills[13], typeof(StealSheep));
        skilldic.Add(skills[14], typeof(Swear));
    }

    void Start()
    {
        InitCard();
        Shuffle();
    }

    //测试代码
    int tst = 0;
    public GameObject nextcard;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (nextcard.GetComponent<BaseSkill>() != null)
            {
                DestroyImmediate(nextcard.GetComponent<BaseSkill>());
            }
            AddSkillToCard(nextcard, deck[tst]);
            tst++;
        }
    }
    //

    //初始化卡牌
    private void InitCard()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            for (int j = 0; j < skills[i].ranks.Count; j++)
            {
                Card card = new Card(skills[i].ranks[j], skills[i].suits[j], skilldic[skills[i]]);
                deck.Add(card);
            }
        }
    }

    //添加牌库中牌的技能组件到物体上
    private void AddSkillToCard(GameObject obj, Card card)
    {
        var newSkill = obj.AddComponent(card.skill);
        newSkill.GetComponent<BaseSkill>().rank = card.rank;
        newSkill.GetComponent<BaseSkill>().suit = card.suit;
    }

    //洗牌
    private void Shuffle()
    {
        System.Random rng = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}
