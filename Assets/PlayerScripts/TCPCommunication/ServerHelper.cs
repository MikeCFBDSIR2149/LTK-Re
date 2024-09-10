using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;
using System;
namespace NetWork
{

    public class ServerHelper : FSM.MonoSingleton<ServerHelper>
    {
        private UdpClient udpService;
        private Thread threadReceive;
        //创建Socket对象（由登录窗口传递服务端Ip，端口）

        public event EventHandler<MessageArrivedEventArgs> MessageArrive;

        private List<IPEndPoint> allClientEP;
        public override void Init()
        {
            base.Init();
            allClientEP = new List<IPEndPoint>();
        }
        public void Initialized(string severIP, int serverPort)
        {
            //跨场景不销毁当前游戏对象
            DontDestroyOnLoad(this.gameObject);
            //创建服务端终结点
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(severIP), serverPort);
            udpService = new UdpClient(serverEP);//随机分配可用的端口

            threadReceive = new Thread(ReceiveChatMessage);
            threadReceive.Start();
        }
        //发送数据
        public void SendChatMessage(Message msg, IPEndPoint remote)
        {
            byte[] buffer = msg.ObjectToBytes();

            udpService.Send(buffer, buffer.Length, remote);
        }
        //接收数据
        private void ReceiveChatMessage()
        {
            while (true)
            {
                IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udpService.Receive(ref remote);
                Message msg = Message.BytesToObject(data);
                //根据消息类型，执行相关逻辑
                OnMessageArrived(msg, remote);
                //引发事件
                if (MessageArrive == null) continue;
                MessageArrivedEventArgs args = new MessageArrivedEventArgs
                {
                   
                };
                //在主线程中引用委托方法
                CrossAssistance.Instance.ExecuteOnMainThread(() => { MessageArrive(this, args); });
            }
        }
        //引发数据（1、事件参数类2、委托3、声明事件4、引发）
        private void OnApplicationQuit()
        {
            threadReceive.Abort();
            udpService.Close();
        }
        private void OnMessageArrived(Message msg, IPEndPoint remote)
        {
            switch (msg.Type)
            {
                case MessageType.Offline:
                    //删除客户端
                    allClientEP.Remove(remote);
                    break;
                case MessageType.Online:
                    //添加客户端
                    allClientEP.Add(remote);
                    break;
                case MessageType.Card:
                    //转发(需要客户端的终结点)
                    //foreach (var item in allClientEP)
                    //    SendChatMessage(msg,item);
                    allClientEP.ForEach(item => SendChatMessage(msg, item));
                    break;
            }
        }
    }
}
