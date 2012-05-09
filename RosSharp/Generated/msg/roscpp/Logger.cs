//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-05-10T01:00:14+09:00
// </auto-generated>
//----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RosSharp.Message;
using RosSharp.Service;
namespace RosSharp.roscpp
{
    ///<exclude/>
    public class Logger : IMessage
    {
        ///<exclude/>
        public Logger()
        {
            name = string.Empty;
            level = string.Empty;
        }
        ///<exclude/>
        public Logger(BinaryReader br)
        {
            Deserialize(br);
        }
        ///<exclude/>
        public string name { get; set; }
        ///<exclude/>
        public string level { get; set; }
        ///<exclude/>
        public string MessageType
        {
            get { return "roscpp/Logger"; }
        }
        ///<exclude/>
        public string Md5Sum
        {
            get { return "a6069a2ff40db7bd32143dd66e1f408e"; }
        }
        ///<exclude/>
        public string MessageDefinition
        {
            get { return "string name\nstring level"; }
        }
        ///<exclude/>
        public bool HasHeader
        {
            get { return false; }
        }
        ///<exclude/>
        public void Serialize(BinaryWriter bw)
        {
            bw.WriteUtf8String(name);
            bw.WriteUtf8String(level);
        }
        ///<exclude/>
        public void Deserialize(BinaryReader br)
        {
            name = br.ReadUtf8String();
            level = br.ReadUtf8String();
        }
        ///<exclude/>
        public int SerializeLength
        {
            get { return 4 + name.Length + 4 + level.Length; }
        }
        ///<exclude/>
        public bool Equals(Logger other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.name.Equals(name) && other.level.Equals(level);
        }
        ///<exclude/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Logger)) return false;
            return Equals((Logger)obj);
        }
        ///<exclude/>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                result = (result * 397) ^ name.GetHashCode();
                result = (result * 397) ^ level.GetHashCode();
                return result;
            }
        }
    }
}
