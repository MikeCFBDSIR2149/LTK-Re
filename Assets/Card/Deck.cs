using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public SkillSO[] skills;
    public Dictionary<SkillSO,BaseSkill> skilldic = new Dictionary<SkillSO,BaseSkill>();

    private void Awake()
    {
        skilldic.Add(skills[0], new ArrowsShot());
        skilldic.Add(skills[1], new BorrowKnife());
        skilldic.Add(skills[2], new BreakBridge());
        skilldic.Add(skills[3], new BumperHarvest());
        skilldic.Add(skills[4], new Creat());
        skilldic.Add(skills[5], new Duel());
        skilldic.Add(skills[6], new FireAttack());
        skilldic.Add(skills[7], new Intrusion());
        skilldic.Add(skills[8], new Invulnerable());
        skilldic.Add(skills[9], new IronChain());
        skilldic.Add(skills[10], new Le());
        skilldic.Add(skills[11], new Lightning());
        skilldic.Add(skills[12], new NoFood());
        skilldic.Add(skills[13], new StealSheep());
        skilldic.Add(skills[14], new Swear());
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
        var newSkill = obj.AddComponent(card.skill.GetType());
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
