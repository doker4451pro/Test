using System.Collections.Generic;

namespace Test
{
    class ListRandCreator
    {
        private ListNode[] arrNodes;
        public ListRandCreator(string line)
        {
            var lineNodes = line.Split(",\n");
            arrNodes = new ListNode[lineNodes.Length];

            for (int i = 0; i < arrNodes.Length; i++)
            {
                arrNodes[i] = new ListNode();
            }

            for (int i = 0; i < arrNodes.Length; i++)
            {
                SetNodesValueFrom(lineNodes[i],arrNodes[i]);
            }
        }

        private void SetNodesValueFrom(string lineNode,ListNode node) 
        {
            lineNode = lineNode.Trim(new char[] { '{', '}' });
            var fieldLines = lineNode.Split(",");
            Dictionary<string, string> fieldToValue = new Dictionary<string, string>();

            foreach (var item in fieldLines)
            {
                var pairs = item.Split(": ");
                fieldToValue.Add(pairs[0], pairs[1]);
            }

            node.Data = fieldToValue["Data"];
            node.Prev = GetFieldNodeFrom(fieldToValue["Prev"]);
            node.Next = GetFieldNodeFrom(fieldToValue["Next"]);
            node.Rand = GetFieldNodeFrom(fieldToValue["Rand"]);
        }

        private ListNode GetFieldNodeFrom(string field) 
        {
            int index = -1;
            if (int.TryParse(field, out index))
                return arrNodes[index];
            else
                return null;
        }

        public void SetValue(ListRand list) 
        {
            list.Head = arrNodes[0];
            list.Tail = arrNodes[arrNodes.Length - 1];
            list.Count = arrNodes.Length;
        }
    }
}
