﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosSharp.Topic;
using RosSharp.Topic.Moles;

namespace RosSharp.Tests.Topic
{
    [TestClass]
    public class PublisherTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ROS.Initialize();
            ROS.TopicTimeout = 3000;
            ROS.XmlRpcTimeout = 3000;
        }

        [TestMethod]
        [HostType("Moles")]
        public void AddTopic_Success()
        {
            MRosTopicClient<std_msgs.String>.AllInstances.StartAsyncSocket = (t1, t2) => Task.Factory.StartNew(() => { });

            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var pub = new Publisher<std_msgs.String>("test", "testnode");

            pub.AddTopic(sock).Wait();
        }
        
        [TestMethod]
        [HostType("Moles")]
        public void AddTopic_Error()
        {
            MRosTopicClient<std_msgs.String>.AllInstances.StartAsyncSocket = 
                (t1, t2) => Task.Factory.StartNew(() => {throw new InvalidOperationException("Start Error");});

            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var pub = new Publisher<std_msgs.String>("test", "testnode");

            var ex = AssertEx.Throws<AggregateException>(() => pub.AddTopic(sock).Wait());
            //ex.InnerException.GetType().Is(typeof(InvalidOperationException));

        }

        [TestMethod]
        [HostType("Moles")]
        public void AddTopic_MultipleTopicSuccess()
        {
            MRosTopicClient<std_msgs.String>.AllInstances.StartAsyncSocket =
                (t1, t2) => Task.Factory.StartNew(() => { });
            MRosTopicClient<std_msgs.String>.AllInstances.SendTaskAsyncTDataType =
                (t1, t2) => Task.Factory.StartNew(() => t2.SerializeLength);

            var sock1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var sock2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var pub = new Publisher<std_msgs.String>("test", "testnode");

            pub.AddTopic(sock1).Wait();
            pub.AddTopic(sock2).Wait();

            pub.OnNext(new std_msgs.String() { data = "test" });
            pub.OnNext(new std_msgs.String() { data = "test" });
            pub.OnNext(new std_msgs.String() { data = "test" });
        }

        [TestMethod]
        [HostType("Moles")]
        public void OnNext_Success()
        {
            MRosTopicClient<std_msgs.String>.AllInstances.StartAsyncSocket = 
                (t1, t2) => Task.Factory.StartNew(() => { });
            MRosTopicClient<std_msgs.String>.AllInstances.SendTaskAsyncTDataType =
                (t1, t2) => Task.Factory.StartNew(() => t2.SerializeLength);

            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var pub = new Publisher<std_msgs.String>("test", "testnode");

            pub.AddTopic(sock).Wait();

            pub.OnNext(new std_msgs.String() { data = "test" });
            pub.OnNext(new std_msgs.String() { data = "test" });
            pub.OnNext(new std_msgs.String() { data = "test" });
        }


    }
}
