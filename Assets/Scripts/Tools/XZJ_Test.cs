using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class XZJ_Test : MonoBehaviour
{
    [MenuItem("测试/UIPanel/Open")]
    static void TestPanelOpen() 
    {
        UIManager.Instance.ShowPanel<TestPanel>(E_UILayer.Top, (panel) =>
        {
            panel.TestFun();
        });
    }

    [MenuItem("测试/UIPanel/Hide")]
    static void TestPanelClose()
    {
        UIManager.Instance.HidePanel<TestPanel>();
    }
}
