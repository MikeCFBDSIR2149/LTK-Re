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

    //字典
    public Dictionary<string, Type> nameTypeDic = new Dictionary<string, Type>(); //name-type
    public Dictionary<Type, SkillSO> typeSODic = new Dictionary<Type, SkillSO>(); //type-SO
    
    void Start()
    {
        RegisterSubclasses();
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
            if (deck.Count > 0)
            {
                AddSkillToCard(nextcard, deck[tst]);
                tst++;
                //Debug.Log(nextcard.GetComponent<BaseSkill>().name);
                //Debug.Log(nextcard.GetComponent<BaseSkill>().rank);
                //Debug.Log(nextcard.GetComponent<BaseSkill>().suit);
            }
            else
                Debug.Log("没牌了");
        }
    }
    //



    //注册子类到字典中
    private void RegisterSubclasses()
    {
        //获取所有子类
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.IsSubclassOf(typeof(BaseSkill)));
        //注册到字典
        foreach (var type in types)
        {
            nameTypeDic[type.Name] = type;
        }
        foreach (SkillSO skill in skills)
        {
            typeSODic.Add(nameTypeDic[skill.name], skill);
        }
    }

    //初始化卡牌
    private void InitCard()
    {
        foreach (var type in typeSODic.Keys)
        {
            for (int i = 0; i < typeSODic[type].ranks.Count; i++)
            {
                Card card = new Card(typeSODic[type].type, typeSODic[type].ranks[i], typeSODic[type].suits[i], type);
                deck.Add(card);
            }
        }
    }

    //添加牌库中牌的技能组件到物体上
    private void AddSkillToCard(GameObject obj, Card card)
    {
        var newSkill = obj.AddComponent(card.skill);
        newSkill.GetComponent<BaseSkill>().type = card.type;
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
