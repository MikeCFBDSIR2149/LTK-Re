using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//技能接口尝试
public interface Iskill1
{
    /// <summary>
    /// 搜索目标
    /// </summary>
    /// <param name="skill">技能数据</param>
    /// <param name="skillTF">技能所在的物体的transform</param>
    /// <returns></returns>
    public Transform[] SelectTarget(Skillstatus skill,Transform skillTF);


}


