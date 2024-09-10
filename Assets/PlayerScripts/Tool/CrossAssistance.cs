using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAssistance : FSM.MonoSingleton<CrossAssistance>//需要挂
{
    //用一个类封装数据
    class DelayedItem
    {
        public Action CurrentAction { get; set; }
        public DateTime Time { get; set; }
    }
    //所有要执行的方法委托
    private List<DelayedItem> actionList;
    //对外提供一个执行的方法
    public void ExecuteOnMainThread(Action actionPre, float delay = 0)
    {
        lock (actionList)//为了防止删除和增加同时进行
        {
            //添加方法委托
            var item = new DelayedItem()
            {
                CurrentAction = actionPre,
                //为了防止调用unity的API，利用c#的时间
                Time = DateTime.Now.AddSeconds(delay)
            };
            actionList.Add(item);
        }
    }
    //初始化
    public override void Init()
    {
        base.Init();
        actionList = new List<DelayedItem>();
    }
    private void Update()
    {
        //执行，从后往前移除元素更方便
        for (int i = actionList.Count - 1; i >= 0; i--)
        {
            if (DateTime.Now > actionList[i].Time)
            {
                actionList[i].CurrentAction();
                actionList.RemoveAt(i);
            }
        }
    }
}
