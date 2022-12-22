using System.Collections.Generic;
using System.Text;

namespace Test
{
    class JsonCreator
    {
        private Dictionary<ListNode, int> pairs;
        private ListRand listRand;

        public JsonCreator(ListRand list) 
        {
            listRand = list;
            pairs = GetDictionaryFrom(listRand);
        }

        private Dictionary<ListNode, int> GetDictionaryFrom(ListRand list)
        {
            Dictionary<ListNode, int> pairs = new Dictionary<ListNode, int>();

            int i = 0;
            ListNode node = list.Head;

            while (node != null)
            {
                pairs.Add(node, i++);
                node = node.Next;
            }

            return pairs;
        }

        public string GetJsonString() 
        {
            StringBuilder sb = new StringBuilder();

            ListNode node = listRand.Head;

            for (int i = 0; i < listRand.Count-1; i++)
            {
                AddToStringBuilder(node, sb);
                sb.Append(",\n");
                node = node.Next;
            }

            AddToStringBuilder(listRand.Tail, sb);

            return sb.ToString();
        }

        private void AddToStringBuilder(ListNode node,StringBuilder sb) 
        {
            sb.Append("{")
                .Append($"Data: {node.Data},")
                .Append($"Prev: {(node.Prev == null ? "null" : pairs[node.Prev].ToString())},")
                .Append($"Next: {(node.Next == null ? "null" : pairs[node.Next].ToString())},")
                .Append($"Rand: {(node.Rand == null ? "null" : pairs[node.Rand].ToString())}")
                .Append("}");
        }

    }
}
