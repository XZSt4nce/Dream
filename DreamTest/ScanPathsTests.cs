using dream;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamTest
{
    [TestClass]
    public class ScanPathsTests
    {
        public bool Compare(Path[] expected, Path[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i].Way.Length != actual[i].Way.Length) return false;
                for (int j = 0; j < expected[i].Way.Length; j++)
                {
                    if (!expected[i].Way[j].Equals(actual[i].Way[j])) return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void ScanPathsTest1()
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
            test.ScanPaths();
            Node[] nodes = test.Nodes.Values.ToArray();
            Path[] expected = new Path[]
            {
                new Path(new Node[]
                {
                    nodes[2],
                    nodes[1],
                    nodes[5],
                    nodes[4]
                }),
                new Path(new Node[]
                {
                    nodes[2],
                    nodes[6],
                    nodes[5],
                    nodes[4]
                })
            };
            Assert.IsTrue(Compare(expected, test.Paths.Values.ToArray()));
        }
    }
}
