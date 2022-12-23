using System.IO;
using System.Text;

namespace Test
{
    class ListNode
    {
        public ListNode Prev;
        public ListNode Next;
        public ListNode Rand; // произвольный элемент внутри списка
        public string Data;
    }

    class ListRand
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(FileStream s)
        {
            JsonCreator jsonCreator = new JsonCreator(this);
            var json = jsonCreator.GetJsonString();
            using (s)
            {
                byte[] buffer = Encoding.Default.GetBytes(json);
                s.Write(buffer);
            }
        }

        public void Deserialize(FileStream s)
        {
            using (s) 
            {
                byte[] buffer = new byte[s.Length];
                s.Read(buffer);
                string textFromFile= Encoding.Default.GetString(buffer);
                ListRandCreator creator = new ListRandCreator(textFromFile);
                creator.SetValue(this);
            }
        }
    }
}
