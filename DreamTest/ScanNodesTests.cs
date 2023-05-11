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

        [TestMethod]
        public void ScanNodesTest2()
        {
            char[,] maze = new char[,]
            {
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
                { 'X', 'S', '.', '.', 'Y', 'G', 'B', '.', '.', '.', '.', 'X' },
                { 'X', '.', '.', 'X', 'X', 'X', 'R', 'X', 'X', 'X', '.', 'X' },
                { 'X', '.', 'Y', 'G', '.', '.', 'E', 'Y', '.', '.', '.', 'X' },
                { 'X', '.', 'X', '.', '.', '.', 'Y', '.', '.', '.', '.', 'X' },
                { 'X', '.', 'X', 'X', 'X', '.', 'X', '.', '.', '.', '.', 'X' },
                { 'X', '.', 'Y', '.', '.', '.', 'X', '.', '.', '.', '.', 'X' },
                { 'X', 'X', '.', 'X', 'X', 'X', 'X', '.', '.', '.', '.', 'X' },
                { 'X', 'X', '.', 'Y', 'G', '.', '.', '.', '.', '.', '.', 'X' },
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' }
            };
            Dream test = new Dream(maze);
            test.ScanNodes();
            Node[] expected = new Node[]
            {
                new Node(1, 1, 'S'),
                new Node(1, 2),
                new Node(1, 6),
                new Node(1, 10),
                new Node(2, 1),
                new Node(2, 2),
                new Node(3, 1),
                new Node(3, 2),
                new Node(3, 3),
                new Node(3, 4),
                new Node(3, 5),
                new Node(3, 6, 'E'),
                new Node(3, 7),
                new Node(3, 8),
                new Node(3, 9),
                new Node(3, 10),
                new Node(4, 3),
                new Node(4, 4),
                new Node(4, 5),
                new Node(4, 6),
                new Node(4, 7),
                new Node(4, 8),
                new Node(4, 9),
                new Node(4, 10),
                new Node(5, 7),
                new Node(5, 8),
                new Node(5, 9),
                new Node(5, 10),
                new Node(6, 1),
                new Node(6, 2),
                new Node(6, 5),
                new Node(6, 7),
                new Node(6, 8),
                new Node(6, 9),
                new Node(6, 10),
                new Node(7, 7),
                new Node(7, 8),
                new Node(7, 9),
                new Node(7, 10),
                new Node(8, 2),
                new Node(8, 7),
                new Node(8, 8),
                new Node(8, 9),
                new Node(8, 10),
            };

            expected[1].AddNeighbor(expected[0]);
            expected[0].AddNeighbor(expected[1]);
            expected[2].AddNeighbor(expected[1]);
            expected[1].AddNeighbor(expected[2]);
            expected[3].AddNeighbor(expected[2]);
            expected[2].AddNeighbor(expected[3]);
            expected[4].AddNeighbor(expected[0]);
            expected[0].AddNeighbor(expected[4]);
            expected[4].AddNeighbor(expected[5]);
            expected[5].AddNeighbor(expected[4]);
            expected[5].AddNeighbor(expected[1]);
            expected[1].AddNeighbor(expected[5]);
            expected[4].AddNeighbor(expected[6]);
            expected[6].AddNeighbor(expected[4]);
            expected[7].AddNeighbor(expected[6]);
            expected[6].AddNeighbor(expected[7]);
            expected[7].AddNeighbor(expected[5]);
            expected[5].AddNeighbor(expected[7]);
            expected[7].AddNeighbor(expected[8]);
            expected[8].AddNeighbor(expected[7]);
            expected[9].AddNeighbor(expected[8]);
            expected[8].AddNeighbor(expected[9]);
            expected[10].AddNeighbor(expected[9]);
            expected[9].AddNeighbor(expected[10]);
            expected[11].AddNeighbor(expected[2]);
            expected[2].AddNeighbor(expected[11]);
            expected[12].AddNeighbor(expected[11]);
            expected[11].AddNeighbor(expected[12]);
            expected[13].AddNeighbor(expected[12]);
            expected[12].AddNeighbor(expected[13]);
            expected[14].AddNeighbor(expected[13]);
            expected[13].AddNeighbor(expected[14]);
            expected[15].AddNeighbor(expected[14]);
            expected[14].AddNeighbor(expected[15]);
            expected[15].AddNeighbor(expected[3]);
            expected[3].AddNeighbor(expected[15]);
            expected[16].AddNeighbor(expected[8]);
            expected[8].AddNeighbor(expected[16]);
            expected[17].AddNeighbor(expected[16]);
            expected[16].AddNeighbor(expected[17]);
            expected[17].AddNeighbor(expected[9]);
            expected[9].AddNeighbor(expected[17]);
            expected[18].AddNeighbor(expected[17]);
            expected[17].AddNeighbor(expected[18]);
            expected[18].AddNeighbor(expected[10]);
            expected[10].AddNeighbor(expected[18]);
            expected[19].AddNeighbor(expected[18]);
            expected[18].AddNeighbor(expected[19]);
            expected[19].AddNeighbor(expected[11]);
            expected[11].AddNeighbor(expected[19]);
            expected[20].AddNeighbor(expected[19]);
            expected[19].AddNeighbor(expected[20]);
            expected[20].AddNeighbor(expected[12]);
            expected[12].AddNeighbor(expected[20]);
            expected[21].AddNeighbor(expected[20]);
            expected[20].AddNeighbor(expected[21]);
            expected[21].AddNeighbor(expected[13]);
            expected[13].AddNeighbor(expected[21]);
            expected[22].AddNeighbor(expected[21]);
            expected[21].AddNeighbor(expected[22]);
            expected[22].AddNeighbor(expected[14]);
            expected[14].AddNeighbor(expected[22]);
            expected[23].AddNeighbor(expected[22]);
            expected[22].AddNeighbor(expected[23]);
            expected[23].AddNeighbor(expected[15]);
            expected[15].AddNeighbor(expected[23]);

            Assert.IsTrue(Compare(expected, test.Nodes.Values.ToArray()));
        }
    }
}
