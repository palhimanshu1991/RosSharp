//----------------------------------------------------------------
// <auto-generated>
//     This code was generated by the GenMsg. Version: 0.1.0.0
//     Don't change it manually.
//     2012-05-10T01:00:08+09:00
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
    public class Float64 : IMessage
    {
        ///<exclude/>
        public Float64()
        {
        }
        ///<exclude/>
        public Float64(BinaryReader br)
        {
            Deserialize(br);
        }
        ///<exclude/>
        public double data { get; set; }
        ///<exclude/>
        public string MessageType
        {
            get { return "std_msgs/Float64"; }
        }
        ///<exclude/>
        public string Md5Sum
        {
            get { return "fdb28210bfa9d7c91146260178d9a584"; }
        }
        ///<exclude/>
        public string MessageDefinition
        {
            get { return "float64 data"; }
        }
        ///<exclude/>
        public bool HasHeader
        {
            get { return false; }
        }
        ///<exclude/>
        public void Serialize(BinaryWriter bw)
        {
            bw.Write(data);
        }
        ///<exclude/>
        public void Deserialize(BinaryReader br)
        {
            data = br.ReadDouble();
        }
        ///<exclude/>
        public int SerializeLength
        {
            get { return 8; }
        }
        ///<exclude/>
        public bool Equals(Float64 other)
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
            if (obj.GetType() != typeof(Float64)) return false;
            return Equals((Float64)obj);
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
