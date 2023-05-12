using Microsoft.VisualStudio.TestTools.UnitTesting;
using dream;
using System.Linq;

namespace DreamTest
{
    [TestClass]
    public class ScanNodes
    {
        private bool Compare(Node[] expected, Node[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (int i = 0; i < expected.Length; i++)
            {
                if (!expected[i].Equals(actual[i])) return false;
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
            Node[] expected = new Node[7]
            {
                new Node(1, 1),
                new Node(1, 3),
                new Node(1, 5, 'E'),
                new Node(2, 1),
                new Node(4, 1, 'S'),
                new Node(4, 3),
                new Node(4, 5)
            };

            expected[0].AddNeighbor(expected[3]);
            expected[3].AddNeighbor(expected[0]);
            expected[1].AddNeighbor(expected[2]);
            expected[2].AddNeighbor(expected[1]);
            expected[4].AddNeighbor(expected[5]);
            expected[5].AddNeighbor(expected[4]);
            expected[5].AddNeighbor(expected[6]);
            expected[6].AddNeighbor(expected[5]);
            expected[6].AddNeighbor(expected[2]);
            expected[2].AddNeighbor(expected[6]);
            expected[1].AddNeighbor(expected[5]);
            expected[5].AddNeighbor(expected[1]);

            expected[2].Colors[1] = 0b1000;
            expected[6].Colors[1] = 0b1000;

            Assert.IsTrue(Compare(expected, test.Nodes.Values.ToArray()));
        }
    }
}
