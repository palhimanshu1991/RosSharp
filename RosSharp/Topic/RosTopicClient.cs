﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Reactive.Linq;
using RosSharp.Message;
using RosSharp.Transport;

namespace RosSharp.Topic
{
    internal sealed class RosTopicClient<TDataType> : IDisposable
        where TDataType : IMessage, new()
    {
        private readonly RosTcpClient _tcpClient;

        public string NodeId { get; private set; }
        public string TopicName { get; private set; }

        public bool IsConnected { get;private set; }

        public RosTopicClient(Socket socket, string nodeId, string topicName)
        {
            IsConnected = false;

            NodeId = nodeId;
            TopicName = topicName;

            _tcpClient = new RosTcpClient(socket);

            _tcpClient.ReceiveAsync()
                .Take(1)
                .Subscribe(OnReceiveHeader);
        }

        public void Dispose()
        {
            _tcpClient.Dispose();
            IsConnected = false;
        }

        //TODO: voidじゃだめでは？
        private void OnReceiveHeader(byte[] data)
        {
            var reqHeader = TcpRosHeaderSerializer.Deserialize(new MemoryStream(data));
            //TODO: 受信したデータのチェック

            var temp = new TDataType();

            var resHeader = new 
            {
                callerid = NodeId,
                latching = "0",
                md5sum = temp.Md5Sum,
                message_definition = temp.MessageDefinition,
                topic = TopicName,
                type = temp.MessageType
            };
            
            var ms = new MemoryStream();
            TcpRosHeaderSerializer.Serialize(ms, resHeader);

            _tcpClient.SendAsync(ms.ToArray()).First(); //TODO: Firstでよい？

            IsConnected = true;
        }

        public IObservable<SocketAsyncEventArgs> SendAsync(TDataType data)
        {
            if(!IsConnected)
            {
                return Observable.Empty<SocketAsyncEventArgs>();
                //throw new InvalidOperationException("Is not Connected.");
            }
            
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);
            bw.Write(data.SerializeLength);
            data.Serialize(bw);
            return _tcpClient.SendAsync(ms.ToArray());
        }

        
    }
}