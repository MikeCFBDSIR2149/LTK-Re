using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPanel :UIPanel
{
    public override void HidePanel()
    {
        print("ClosePanel");
    }

    public override void ShowPanel()
    {
        print("ShoePanel");
    }

    public void TestFun()
    {
        Debug.Log("测试通过");
    }
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
