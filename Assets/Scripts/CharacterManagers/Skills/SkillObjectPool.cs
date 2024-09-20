using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//技能池实现
public class SkillObjectPool : MonoBehaviour
{
    public static SkillObjectPool Instance;
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private Dictionary<string, GameObject> prefabDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public GameObject CreateObject(string prefabName, GameObject prefab)
    {
        
        GameObject obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(prefab);
        }
        return obj;
    }

    public void CollectObject(GameObject obj, float delay)
    {
        StartCoroutine(ReturnToPool(obj, delay));
    }

    private IEnumerator ReturnToPool(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
    //确保在游戏开始时预加载对象，这样可以提高性能。
    public void Preload(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}
