using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MessageLibrary
{
    [Serializable]
    public class LanMessage
    {
        public string MessageText { get; set; }
        public DateTime Time { get; private set; }
        public LanMessage(string text)
        {
            Time = DateTime.Now;
            MessageText = text;
        }
        public override string ToString()
        {
            return $"({Time.ToLongTimeString()} {Time.ToShortDateString()}){MessageText}";
        }
        public static byte[] SerializeMessage(LanMessage message)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, message);
            ms.Position = 0;
            return ms.ToArray();
        }
        public static LanMessage DeserializeMessage(byte[] buffer)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(buffer);
            return (bf.Deserialize(ms) as LanMessage);
        }
    }
}
