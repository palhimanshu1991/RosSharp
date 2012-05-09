//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-05-10T01:00:10+09:00
// </auto-generated>
//----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RosSharp.Message;
using RosSharp.Service;
namespace RosSharp.std_msgs
{
    ///<exclude/>
    public class Time : IMessage
    {
        ///<exclude/>
        public Time()
        {
        }
        ///<exclude/>
        public Time(BinaryReader br)
        {
            Deserialize(br);
        }
        ///<exclude/>
        public DateTime data { get; set; }
        ///<exclude/>
        public string MessageType
        {
            get { return "std_msgs/Time"; }
        }
        ///<exclude/>
        public string Md5Sum
        {
            get { return "cd7166c74c552c311fbcc2fe5a7bc289"; }
        }
        ///<exclude/>
        public string MessageDefinition
        {
            get { return "time data"; }
        }
        ///<exclude/>
        public bool HasHeader
        {
            get { return false; }
        }
        ///<exclude/>
        public void Serialize(BinaryWriter bw)
        {
            bw.WriteDateTime(data);
        }
        ///<exclude/>
        public void Deserialize(BinaryReader br)
        {
            data = br.ReadDateTime();
        }
        ///<exclude/>
        public int SerializeLength
        {
            get { return 8; }
        }
        ///<exclude/>
        public bool Equals(Time other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.data.Equals(data);
        }
        ///<exclude/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Time)) return false;
            return Equals((Time)obj);
        }
        ///<exclude/>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                result = (result * 397) ^ data.GetHashCode();
                return result;
            }
        }
    }
}
