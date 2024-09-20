
using UnityEngine;
//角色阵营
public enum CampType
{
    Wu,
    Su,
    Wei,
}
//角色属性
public abstract class PeopleBase:MonoBehaviour
{
    public int Gender { get; set; }
    public string ExtraName { get; set; }
    public string Name { get; set; }
    protected CampType Type { get; set; }
    public int MaxHp 
    { 
        get
        {
            return maxHpValuel;
        }
        set
        {
            maxHpValuel = value;
            Hp = MaxHp;
        }
    }

    private int maxHpValuel;
    public int Hp;
    public int NowHp { get; set; }
    
    
}
//角色阵营分配以及阵营相关
public class GeneralCamp:PeopleBase
{
    private CommunicationBridge communicationBridge = new CommunicationBridge();

    private delegate void GeneralDelegate();

    private GeneralDelegate wuDelegate;
    private GeneralDelegate suDelegate;
    private GeneralDelegate weiDelegate;

    public void Wu()
    {
        print("吴");
    }

    public void Su()
    {
        print("蜀");
    }

    public void Wei()
    {
        print("魏");
    }
//利用委托实现阵营相关
    public void Camp()
    {
        wuDelegate = Wu;
        suDelegate = Su;
        weiDelegate = Wei;
        switch (Type)
        {
            case CampType.Wu:
                wuDelegate.Invoke();
                break;
            case CampType.Su:
                suDelegate.Invoke();
                break;
            case CampType.Wei:
                weiDelegate.Invoke();
                break;
            default:
                Debug.LogError("Unknown CampType");
                break;
        }
    }

    public void CurrentHp()
    {
        if (communicationBridge.playerCurrentHealth != Hp)
        {
            communicationBridge.playerCurrentHealth = Hp;
            print("PlayerHp="+communicationBridge.playerCurrentHealth);
        }
    }
    //技能管理器
    public virtual void SkillManager()
    {
        // 实现技能逻辑
        
        
    }

    
}
    
