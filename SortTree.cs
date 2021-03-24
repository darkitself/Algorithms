using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    public static class TreeSort
    {
        public static List<string> MakeTreeSort(List<string> collection, Func<string, string, int> comparator = default)
        {
            if (comparator == null)
                comparator = string.CompareOrdinal;
            var treeNode = new TreeNode(collection[0]);
            for (var i = 1; i < collection.Count; i++)
                treeNode.Add(new TreeNode(collection[i]), comparator);

            return treeNode.Transform().ToList();
        }

        public class TreeNode
        {
            public TreeNode(string data) => Data = data;
            public string Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public void Add(TreeNode node, Func<string, string, int> comparator = default)
            {
                if (comparator == null)
                    comparator = string.CompareOrdinal;
                if (comparator(node.Data, Data) < 0)
                    if (Left == null)
                        Left = node;
                    else Left.Add(node, comparator);
                else if (Right == null)
                    Right = node;
                else Right.Add(node, comparator);
            }

            public IEnumerable<string> Transform()
            {
                if (Left != null)
                    foreach (var value in Left.Transform())
                        yield return value;

                yield return Data;

                if (Right != null)
                    foreach (var value in Right.Transform())
                        yield return value;
            }
        }
    }
}