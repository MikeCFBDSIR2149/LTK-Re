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
    public class ClientHelper : FSM.MonoSingleton<ClientHelper>
    {
        private UdpClient udpService;
        private Thread threadReceive;
        //创建Socket对象（由登录窗口传递服务端Ip，端口）

        public event EventHandler<MessageArrivedEventArgs> MessageArrive;
        public void Initialized(string severIP, int serverPort)
        {
            //跨场景不销毁当前游戏对象
            DontDestroyOnLoad(this.gameObject);
            //创建服务端终结点
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(severIP), serverPort);
            udpService = new UdpClient();//随机分配可用的端口
            //与服务端建立连接（没有三次握手）
            udpService.Connect(serverEP);
            threadReceive = new Thread(ReceiveChatMessage);
            threadReceive.Start();
            //发送上线消息
            NotifyServer(MessageType.Online);
        }
        private void NotifyServer(MessageType type)
        {
            SendChatMessage(new Message() { Type = type });
        }
        //发送数据
        public void SendChatMessage(Message msg)
        {
            byte[] buffer = msg.ObjectToBytes();
            //备注：发送时不能指定中断（创建Socket对象时，建立了链接）
            udpService.Send(buffer, buffer.Length);
        }
        //接收数据
        private void ReceiveChatMessage()
        {
            while (true)
            {
                IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udpService.Receive(ref remote);
                Message msg = Message.BytesToObject(data);
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
            //发送下线消息
            NotifyServer(MessageType.Offline);
            threadReceive.Abort();
            udpService.Close();
        }
    }
}
