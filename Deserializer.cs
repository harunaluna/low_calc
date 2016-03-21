
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;


namespace AMFAPI
{
    internal class Deserializer : BinaryReader
    {
        #region Fiels and Properties
        internal static readonly DateTime BaseDate = new DateTime(1970, 1, 1);
        #endregion

        #region Constructors

        public Deserializer(Stream input)
            : base(input)
        {

        }
        #endregion

        #region Public Methods
        public object Deserialize()
        {
            if (BaseStream.Length == 0)
            {
                return new object();
            }
            List<object> message = new List<object>();
            ReadUInt16();
            int headerCount = ReadUInt16();
            for (int i = 0; i < headerCount; ++i)
            {
                string key = ReadShortString();
                bool required = ReadBoolean();
                int length = ReadInt32(); 
                object data = ReadData(ReadByte());
            }
            int bodyCount = ReadUInt16();
            for (int i = 0; i < bodyCount; ++i)
            {
                string rawMethod = ReadShortString();
                string nullstr = ReadShortString();
                ReadInt32();//skipdata
                object data = ReadData(ReadByte());
                message.Add(data);
            }
            return message;
        }

        #endregion

        #region Private Readers
        private object ReadData(byte type)
        {
            DataType t = (DataType)type;
            switch (t)
            {
                case DataType.Number:
                    return ReadDouble();
                case DataType.Boolean:
                    return ReadBoolean();
                case DataType.String:
                    return ReadShortString();
                case DataType.Array:
                    return ReadArray();
                case DataType.Date:
                    return ReadDate();
                case DataType.LongString:
                    return ReadLongString();;
                case DataType.MixedArray:
                    return ReadDictionary();
                case DataType.Null:
                case DataType.Undefined:
                case DataType.End:
                    return null;
                case DataType.UntypedObject:
                    return ReadUntypedObject();
                case DataType.Xml:
                    return ReadXmlDocument();
                case DataType.MovieClip:
                case DataType.ReferencedObject:
                case DataType.TypeAsObject:
                case DataType.Recordset:
                    break;
            }
            return null;
        }

        private Hashtable ReadDictionary()
        {
            int size = ReadInt32();
            Hashtable hash = new Hashtable(size);
            string key = ReadShortString();
            for (byte type = ReadByte(); type != 9; type = ReadByte())
            {
                object value = ReadData(type);
                hash.Add(key, value);
                key = ReadShortString();
            }
            return hash;
        }
        private DateTime ReadDate()
        {
            double ms = ReadDouble();
            DateTime date = BaseDate.AddMilliseconds(ms);
            ReadUInt16(); //get's the timezone
            return date;
        }
        private new double ReadDouble()
        {
            return BitConverter.ToDouble(ReadInternal(8), 0);
        }

        private new int ReadInt32()
        {
            return BitConverter.ToInt32(ReadInternal(4), 0);
        }

        private new ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(ReadInternal(2), 0);
        }

        private byte[] ReadInternal(int size)
        {
            byte[] buffer = new byte[size];
            for (int i = size - 1; i >= 0; --i)
            {
                buffer[i] = ReadByte();
            }
            return buffer;
        }
        private string ReadLongString()
        {
            int length = ReadInt32();
            return ReadString(length);
        }
        private string ReadShortString()
        {
            int length = ReadUInt16();
            return ReadString(length);
        }
        private string ReadString(int length)
        {
            byte[] buffer = new byte[length];
            Read(buffer, 0, length);
            return Encoding.UTF8.GetString(buffer);
        }
        private XmlDocument ReadXmlDocument()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ReadLongString());
            return xml;
        }

        private Hashtable ReadUntypedObject()
        {
            Hashtable hash = new Hashtable();
            string key = ReadShortString();
            for (byte type = ReadByte(); type != 9; type = ReadByte())
            {
                hash.Add(key, ReadData(type));
                key = ReadShortString();
            }
            return hash;
        }

        private ArrayList ReadArray()
        {
            int size = ReadInt32();
            ArrayList arr = new ArrayList(size);
            for (int i = 0; i < size; ++i)
            {
                arr.Add(ReadData(ReadByte()));
            }
            return arr;
        }
        #endregion
    }

   public enum DataType
   {
       Number = 0,
       Boolean = 1,
       String = 2,
       UntypedObject = 3,
       MovieClip = 4,
       Null = 5,
       Undefined = 6,
       ReferencedObject = 7,
       MixedArray = 8,
       End = 9,
       Array = 10,
       Date = 11,
       LongString = 12,
       TypeAsObject = 13,
       Recordset = 14,
       Xml = 15,
       TypedObject = 16
   }
}