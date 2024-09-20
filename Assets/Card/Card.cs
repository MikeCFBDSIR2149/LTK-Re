using System;

public class Card 
{
    public SkillType type;
    public Rank rank;
    public Suit suit;
    public Type skill;

    public Card(SkillType type, Rank rank, Suit suit, Type skill)
    {
        this.type = type;
        this.rank = rank;
        this.suit = suit;
        this.skill = skill;
    }
}
