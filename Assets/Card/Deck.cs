using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public List<BasicCard> basic = new List<BasicCard>();
    public List<SkillCard> skill = new List<SkillCard>();
    public List<EquipCard> equip = new List<EquipCard>();

    public SkillSO[] skills;
    public Dictionary<SkillSO,BaseSkill> skilldic = new Dictionary<SkillSO,BaseSkill>();

    //#region 技能SO文件
    //public SkillSO ArrowsShot;
    //public SkillSO BreakBridge;
    //public SkillSO StealSheep;
    //public SkillSO Creat;
    //public SkillSO Duel;
    //public SkillSO BorrowKnife;
    //public SkillSO Swear;
    //public SkillSO BumperHarvest;
    //public SkillSO Intrusion;
    //public SkillSO Invulnerable;
    //public SkillSO FireAttack;
    //public SkillSO IronChain;
    //public SkillSO Le;
    //public SkillSO NoFood;
    //public SkillSO Lightning;
    //#endregion

    //#region 技能脚本
    //public ArrowsShot arrowsShot;
    //public BreakBridge breakBridge;
    //public StealSheep stealSheep;
    //public Creat creat;
    //public Duel duel;
    //public BorrowKnife borrowKnife;
    //public Swear swear;
    //public BumperHarvest bumperHarvest;
    //public Intrusion intrusion;
    //public Invulnerable invulnerable;
    //public FireAttack fireAttack;
    //public IronChain ironChain;
    //public Le le;
    //public NoFood noFood;
    //public Lightning lightning;
    //#endregion

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
        CreatDeck();
        Shuffle();
    }

    //初始化卡牌
    private void InitCard()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            for (int j = 0; j < skills[i].ranks.Count; j++)
            {
                SkillCard card = new SkillCard(skills[i].ranks[j], skills[i].suits[j], skilldic[skills[i]]);
                deck.Add(card);
            }
        }
    }

    //生成牌组
    private void CreatDeck()
    {
        deck.AddRange(basic);
        deck.AddRange(skill);
        deck.AddRange(equip);
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
