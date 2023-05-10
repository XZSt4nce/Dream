using Microsoft.VisualStudio.TestTools.UnitTesting;
using dream;
using System.Collections.Generic;
using System.Linq;

namespace DreamTest
{
    [TestClass]
    public class ScanNodes
    {
        private bool Compare(Dictionary<int[], Node> dict1, Dictionary<int[], Node> dict2)
        {
            Node[] nodes1 = dict1.Values.ToArray();
            Node[] nodes2 = dict2.Values.ToArray();
            if (nodes1.Length != nodes2.Length) return false;
            for (int i = 0; i < nodes1.Length; i++)
            {
                if (!nodes1[i].Equals(nodes2[i])) return false;
            }
            return true;
        }

        private Dictionary<int[], Node> AddNodes(Node[] nodes)
        {
            int[] key;
            Dictionary<int[], Node> dict = new Dictionary<int[], Node>();
            foreach (Node node in nodes)
            {
                key = new int[] { node.Row, node.Column };
                dict.Add(key, node);
            }
            return dict;
        }

        [TestMethod]
        public void ScanNodesTest1()
        {
            char[,] maze = new char[,]
            {
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
                { 'X', '.', 'X', '.', '.', 'E', 'X' },
                { 'X', '.', 'X', '.', 'X', 'R', 'X' },
                { 'X', 'X', 'X', '.', 'X', '.', 'X' },
                { 'X', 'S', '.', '.', '.', '.', 'X' },
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X' }
            };
            Dream test = new Dream(maze);
            test.ScanNodes();
            Node[] nodes = new Node[7]
            {
                new Node(1, 1),
                new Node(1, 3),
                new Node(1, 5, 'E'),
                new Node(2, 1),
                new Node(4, 1, 'S'),
                new Node(4, 3),
                new Node(4, 5)
            };

            nodes[2].Colors[1] = 0b1000;
            nodes[6].Colors[1] = 0b1000;

            nodes[0].AddNeighbor(nodes[3]);
            nodes[3].AddNeighbor(nodes[0]);
            nodes[1].AddNeighbor(nodes[2]);
            nodes[2].AddNeighbor(nodes[1]);
            nodes[4].AddNeighbor(nodes[5]);
            nodes[5].AddNeighbor(nodes[4]);
            nodes[5].AddNeighbor(nodes[6]);
            nodes[6].AddNeighbor(nodes[5]);
            nodes[6].AddNeighbor(nodes[2]);
            nodes[2].AddNeighbor(nodes[6]);
            nodes[1].AddNeighbor(nodes[5]);
            nodes[5].AddNeighbor(nodes[1]);

            Dictionary<int[], Node> expected = AddNodes(nodes);
            Assert.IsTrue(Compare(expected, test.Nodes));
        }
    }
}
