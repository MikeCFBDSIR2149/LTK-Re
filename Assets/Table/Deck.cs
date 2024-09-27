using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //牌库
    public List<Card> deck = new List<Card>();

    [Header("牌型SO文件")]
    public SkillSO[] skills;    //存放每种牌所有点数与对应花色
    [Header("装备类SO文件")]
    public EquipSO[] equips;    //存放主要装备牌类型

    //字典
    public Dictionary<string, Type> nameTypeDic = new Dictionary<string, Type>(); //name-type
    public Dictionary<Type, SkillSO> typeSODic = new Dictionary<Type, SkillSO>(); //type-SO
    
    void Start()
    {
        RegisterSubclasses();
        InitCard();
        Shuffle();
    }

    //注册子类到字典中
    private void RegisterSubclasses()
    {
        //获取所有子类
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.IsSubclassOf(typeof(BaseSkill)) && !type.IsAbstract)
            .ToList();
        //注册到字典
        foreach (var type in types)
        {
            nameTypeDic[type.Name] = type;      //写入子类string及对应type
        }
        foreach (SkillSO skill in skills)
        {
            typeSODic.Add(nameTypeDic[skill.name], skill);      //写入子类type及对应SO
        }
        foreach (EquipSO equip in equips)
        {
            foreach (var item in equip.equipments)      //遍历string列表
            {
                if (!typeSODic.ContainsKey(nameTypeDic[item]))      //防止添加相同键值
                    typeSODic.Add(nameTypeDic[item], equip);
            }
        }
    }

    //初始化卡牌
    private void InitCard()
    {
        int count = 0;      //记牌数
        foreach (var type in typeSODic.Keys)    //type:具体的类
        {
            if (type.IsSubclassOf(typeof(BaseEquip))
                && typeSODic[type] is EquipSO equipSO)    //判断type是否为装备类,并将字典值转为equipSO
            {
                int i = equipSO.equipments.IndexOf(type.FullName);    //根据name找到索引,从索引开始计数
                do
                {
                    Card nextCard = new Card(typeSODic[type].cardType, equipSO.skillType, equipSO.ranks[i], equipSO.suits[i], type);
                    deck.Add(nextCard);
                    count++;
                } while (equipSO.isNextSame[i++]);    //根据列表判断下一张是否类不变
                continue;       //进入下一个type,防止重复生成
            }
            for (int i = 0; i < typeSODic[type].ranks.Count; i++)
            {
                Card card = new Card(typeSODic[type].cardType, typeSODic[type].skillType, typeSODic[type].ranks[i], typeSODic[type].suits[i], type);
                deck.Add(card);
                count++;
            }
        }
        Debug.Log("牌数:" + count);
    }

    //添加牌库的技能组件到物体上
    public void AddSkillToCard(GameObject obj, Card card)
    {
        var newSkill = obj.AddComponent(card.skill);
        newSkill.GetComponent<BaseSkill>().cardType = card.cardType;
        newSkill.GetComponent<BaseSkill>().skillType = card.skillType;
        newSkill.GetComponent<BaseSkill>().rank = card.rank;
        newSkill.GetComponent<BaseSkill>().suit = card.suit;
    }

    //洗牌
    public void Shuffle()
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
