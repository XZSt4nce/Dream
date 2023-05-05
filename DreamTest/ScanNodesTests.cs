using Microsoft.VisualStudio.TestTools.UnitTesting;
using dream;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DreamTest
{
    [TestClass]
    public class ScanNodes
    {
        public bool Compare(HashSet<Node> set1, HashSet<Node> set2)
        {
            Node[] nodes1 = set1.ToArray();
            Node[] nodes2 = set2.ToArray();
            if (nodes1.Length != nodes2.Length) return false;
            for (int i = 0; i < nodes1.Length; i++)
            {
                if (!nodes1[i].Equals(nodes2[i])) return false;
            }
            return true;
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
            HashSet<Node> expected = new HashSet<Node>
            {
                new Node(1, 1),
                new Node(1, 3),
                new Node(1, 5, 'E'),
                new Node(2, 1),
                new Node(4, 1, 'S'),
                new Node(4, 3),
                new Node(4, 5)
            };
            Assert.IsTrue(Compare(expected, test.Nodes));
        }
    }
}
