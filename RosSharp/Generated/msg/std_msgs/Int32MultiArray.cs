//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-05-10T01:00:09+09:00
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
    public class Int32MultiArray : IMessage
    {
        ///<exclude/>
        public Int32MultiArray()
        {
            layout = new MultiArrayLayout();
            data = new List<int>();
        }
        ///<exclude/>
        public Int32MultiArray(BinaryReader br)
        {
            Deserialize(br);
        }
        ///<exclude/>
        public MultiArrayLayout layout { get; set; }
        ///<exclude/>
        public List<int> data { get; set; }
        ///<exclude/>
        public string MessageType
        {
            get { return "std_msgs/Int32MultiArray"; }
        }
        ///<exclude/>
        public string Md5Sum
        {
            get { return "1d99f79f8b325b44fee908053e9c945b"; }
        }
        ///<exclude/>
        public string MessageDefinition
        {
            get { return "MultiArrayLayout layout\nint32[] data"; }
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
            data = new List<int>(br.ReadInt32()); for(int i=0; i<data.Capacity; i++) { var x = br.ReadInt32();data.Add(x);}
        }
        ///<exclude/>
        public int SerializeLength
        {
            get { return layout.SerializeLength + 4 + data.Sum(x => 4); }
        }
        ///<exclude/>
        public bool Equals(Int32MultiArray other)
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
            if (obj.GetType() != typeof(Int32MultiArray)) return false;
            return Equals((Int32MultiArray)obj);
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
