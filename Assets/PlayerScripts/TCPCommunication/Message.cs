using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
namespace NetWork
{
    public enum MessageType
    {
        Online,
        Offline,
        Choose,//选择对手
        Bechosen,//被选择
        Card,//出牌
        Skill,//角色技能选择
        Refuse//不出
    }
    public class Message
    {
        public MessageType Type { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 对象转换为字节数组
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] ObjectToBytes()
        {
            //对象变成字节数组 string/int/bool - 二进制写入器->内存流MemroyStream-》 byte[]
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryWriter writer = new BinaryWriter(stream);
                WriteString(writer, Type.ToString());
                WriteString(writer, SenderName);
                WriteString(writer, Content);
                return stream.ToArray();
            }
        }

        private void WriteString(BinaryWriter writer, string str)
        {
            byte[] typeBTS = Encoding.Unicode.GetBytes(str);
            //写入长度
            writer.Write(typeBTS.Length);
            //写入内容
            writer.Write(typeBTS);
        }
        /// <summary>
        /// 将字节数组转换为对象
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>ChatMessage</returns>
        public static Message BytesToObject(byte[] bytes)
        {
            //创建聊天消息对象
            Message obj = new Message();
            //byte[]   --内存流--二进制读取器--》string/int/bool
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                BinaryReader reader = new BinaryReader(stream);

                string strType = ReadString(reader);
                obj.Type = (MessageType)Enum.Parse(typeof(MessageType), strType);
                obj.SenderName = ReadString(reader);
                obj.Content = ReadString(reader);
                return obj;
            }
        }

        private static string ReadString(BinaryReader reader)
        {
            int Length = reader.ReadInt32();//自动读4个字节
            byte[] BTS = reader.ReadBytes(Length);
            return Encoding.Unicode.GetString(BTS);
        }
    }
}
