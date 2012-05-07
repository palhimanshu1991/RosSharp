//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-05-07T22:03:57+09:00
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
    public class UInt16MultiArray : IMessage
    {
        ///<exclude/>
        public UInt16MultiArray()
        {
            layout = new MultiArrayLayout();
            data = new List<ushort>();
        }
        ///<exclude/>
        public UInt16MultiArray(BinaryReader br)
        {
            Deserialize(br);
        }
        ///<exclude/>
        public MultiArrayLayout layout { get; set; }
        ///<exclude/>
        public List<ushort> data { get; set; }
        ///<exclude/>
        public string MessageType
        {
            get { return "std_msgs/UInt16MultiArray"; }
        }
        ///<exclude/>
        public string Md5Sum
        {
            get { return "52f264f1c973c4b73790d384c6cb4484"; }
        }
        ///<exclude/>
        public string MessageDefinition
        {
            get { return "MultiArrayLayout layout\nuint16[] data"; }
        }
        ///<exclude/>
        public bool HasHeader
        {
            get { return false; }
        }
        ///<exclude/>
        public void Serialize(BinaryWriter bw)
        {
            layout.Serialize(bw);
            bw.Write(data.Count); for(int i=0; i<data.Count; i++) { bw.Write(data[i]);}
        }
        ///<exclude/>
        public void Deserialize(BinaryReader br)
        {
            layout = new MultiArrayLayout(br);
            data = new List<ushort>(br.ReadInt32()); for(int i=0; i<data.Count; i++) { data[i] = br.ReadUInt16();}
        }
        ///<exclude/>
        public int SerializeLength
        {
            get { return layout.SerializeLength + 4 + data.Sum(x => 2); }
        }
        ///<exclude/>
        public bool Equals(UInt16MultiArray other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.layout.Equals(layout) && other.data.Equals(data);
        }
        ///<exclude/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(UInt16MultiArray)) return false;
            return Equals((UInt16MultiArray)obj);
        }
        ///<exclude/>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                result = (result * 397) ^ layout.GetHashCode();
                result = (result * 397) ^ data.GetHashCode();
                return result;
            }
        }
    }
}
