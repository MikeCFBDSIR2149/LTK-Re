using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//需要挂载的单例脚本
[DisallowMultipleComponent]//禁止同一物体多次挂载
public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance 
    {   get 
        {
            if (instance == null)
            {
                //手动挂载式
                instance = FindAnyObjectByType<T>();
                //自动挂载式
                if (instance == null)
                {
                    //非挂载式单例在被调用时直接创建
                    GameObject newManager = new GameObject(typeof(T) + "SingleManager");
                    instance = newManager.AddComponent<T>();
                    DontDestroyOnLoad(newManager);
                }
            }
            return instance;

        }
    }
    protected virtual void Awake() 
    {
        //手动重复挂载检测
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        //自动挂载式初始化
        if(instance == null)
        {
            instance = this as T; 
        }
        DontDestroyOnLoad(this.gameObject);

    }

}
