using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//技能池实现
public class SkillObjectPool : MonoBehaviour
{
    public static SkillObjectPool Instance;
    public GameObject prefab;
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject CreateObject(string prefabName, GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj;
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
        }
        else
        {
            obj = Instantiate(prefab, position, rotation);
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
