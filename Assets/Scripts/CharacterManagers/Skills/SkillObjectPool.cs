using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//技能池实现
public class SkillObjectPool : MonoSingleton<SkillObjectPool>
{
   //对象池的字典，事实上是放了好几个对象池
    //key：对象类型的字符串
    private Dictionary<string, List<GameObject>> cahe;
    //初始化
    protected override void Awake()
    {
        base.Awake();
        cahe = new Dictionary<string, List<GameObject>>();
    }
 
    //需要的参数：对象类型字符串，对象预制体，位置，旋转
    public GameObject CreateObject(string key , GameObject prefab )
    {
        //FindUseableObject：寻找对象池中是否有可用的对象
        GameObject go = FindUsableObject(key);
        //如果没有在场景中创建该对象的物体
        if (go == null)
        {
            //AddObject：创建对象
            go = AddObject(key, prefab);
        }
 
        //初始化需要创建的对象
        UseObject(go);
        return go;
    }
 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="go">回收对象</param>
    /// <param name="delay">延迟</param>
    public void CollectObject(GameObject go,float delay =0)
    {
        //协程用于延迟回收
        StartCoroutine(CollectObjectDelay(go,delay));
    }
 
    //清空
    //一般清空是倒着清空
    public void Clear(string key)
    {
        if (cahe.ContainsKey(key))
        {
            foreach(GameObject go in cahe[key])
            {
                Destroy(go);
            }
            cahe.Remove(key);
        }
    }
 
    //清空所有
    public void ClearAll()
    {
        foreach (List<GameObject> go in cahe.Values)
        {
            foreach(GameObject go1 in go)
            {
                Destroy(go1);
            }
        }
        cahe.Clear();
    }
 
    //回收对象：把对象的active设成false
    private IEnumerator CollectObjectDelay(GameObject go,float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
 
    //初始化对象
    private static void UseObject(GameObject go)
    {
        //go.transform.position = pos;
        //go.transform.rotation = quaternion;
        go.SetActive(true);
        //遍历执行物体中需要重置的脚本
        foreach(var item in go.GetComponents<IResetable>())
        {
            item.OnReset();
        }
    }
 
    //创建预制体，并加入字典（对象池）中
    private GameObject AddObject(string key, GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        if (!cahe.ContainsKey(key))
            cahe.Add(key, new List<GameObject>());
        cahe[key].Add(go);
        return go;
    }
 
    //查找对象池中是否有该类型的物体
    private GameObject FindUsableObject(string key)
    {
        if (cahe.ContainsKey(key))
             return cahe[key].Find(g => !g.activeInHierarchy);
        return null;
    }
}
