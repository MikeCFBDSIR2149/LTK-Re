using System;

public class Card 
{
    public CardType cardType;
    public SkillType skillType;
    public Rank rank;
    public Suit suit;
    public Type skill;

    public Card(CardType cardType, SkillType skilltype, Rank rank, Suit suit, Type skill)
    {
        this.cardType = cardType;
        this.skillType = skilltype;
        this.rank = rank;
        this.suit = suit;
        this.skill = skill;
    }
}
