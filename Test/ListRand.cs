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

        }
    }
}
