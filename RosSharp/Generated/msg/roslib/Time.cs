//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-04-07T13:04:48+09:00
// </auto-generated>
//----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RosSharp.Message;
using RosSharp.Service;
namespace RosSharp
{
    public class Time : IMessage
    {
        public Time()
        {
            header = new Header();
        }
        public Time(BinaryReader br)
        {
            Deserialize(br);
        }
        public Header header { get; set; }
        public DateTime rostime { get; set; }
        public string MessageType
        {
            get { return "Time"; }
        }
        public string Md5Sum
        {
            get { return "09c1c9ce296734b4da898e62d1d0ae17"; }
        }
        public string MessageDefinition
        {
            get { return "Header header\ntime rostime"; }
        }
        public void Serialize(BinaryWriter bw)
        {
            header.Serialize(bw);
            bw.WriteDateTime(rostime);
        }
        public void Deserialize(BinaryReader br)
        {
            header = new Header();
            rostime = br.ReadDateTime();
        }
        public int SerializeLength
        {
            get { return header.SerializeLength + 8; }
        }
        public bool Equals(Time other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.header.Equals(header) && other.rostime.Equals(rostime);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Time)) return false;
            return Equals((Time)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                result = (result * 397) ^ header.GetHashCode();
                result = (result * 397) ^ rostime.GetHashCode();
                return result;
            }
        }
    }
}