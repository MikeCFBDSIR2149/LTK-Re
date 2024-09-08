using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ҫ���صĵ����ű�
[DisallowMultipleComponent]//��ֹͬһ�����ι���
public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private  static  T  instance;
    public static T Instance 
    {   get 
        {
            if (instance == null)
            {
                //�ֶ�����ʽ
                instance = FindAnyObjectByType<T>();
                //�Զ�����ʽ
                if (instance == null)
                {
                    //�ǹ���ʽ�����ڱ�����ʱֱ�Ӵ���
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
        //�ֶ��ظ����ؼ��
        if(instance!=null)
        {
            Destroy(this);
            return;
        }

        //�Զ�����ʽ��ʼ��
        if(instance==null)
        {
            instance=this as T; 
        }
        DontDestroyOnLoad(this.gameObject);

    }

}
