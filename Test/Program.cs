using System.Collections.Generic;
using System.IO;

namespace Test
{
    class Program
    {
        private static string path = "note.json";
        static void Main(string[] args)
        {
            ListRand list = new ListRand();
            Init(ref list);

            FileStream file = new FileStream(path,FileMode.OpenOrCreate);
            list.Serialize(file);
        }

        #region Init
        private static void Init(ref ListRand list) 
        {
            list = new ListRand();
            List<ListNode> listNodes = new List<ListNode>();

            SetDataTo(listNodes);
            SetConnectionTo(listNodes);

            list.Head = listNodes[0];
            list.Tail = listNodes[listNodes.Count - 1];
            list.Count = listNodes.Count;
        }
        private static void SetDataTo(List<ListNode> listNodes) 
        {
            for (int i = 0; i < 5; i++)
            {
                var node = new ListNode();
                node.Data = i.ToString();
                listNodes.Add(node);
            }
        }

        private static void SetConnectionTo(List<ListNode> listNodes)
        {
            SetTwoWayConnectionTo(listNodes);
            SetRandomConnectionTo(listNodes);
        }

        private static void SetTwoWayConnectionTo(List<ListNode> listNodes) 
        {
            for (int i = 0; i < listNodes.Count - 1; i++)
            {
                listNodes[i].Next = listNodes[i + 1];
                listNodes[i + 1].Prev = listNodes[i];
            }
        }

        private static void SetRandomConnectionTo(List<ListNode> listNodes) 
        {
            listNodes[1].Rand = listNodes[1];
            listNodes[2].Rand = listNodes[4];
            listNodes[3].Rand = listNodes[0];
        }
        #endregion
    }
}
