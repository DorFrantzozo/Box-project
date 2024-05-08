using System.Collections.Generic;

namespace BoxModels.Models
{
    public class TreeNode
    {
        public double Width { get; set; }
        public HeightTree HeightTr { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }


        public TreeNode(double value)
        {
            Width = value;
            Left = null;
            Right = null;
        }


        public TreeNode Search(double value)
        {
            if (this == null || value == Width)
            {
                return this;
            }
            if (Width > value)
            {
                return Left?.Search(value);
            }
            else
            {
                return Right?.Search(value);
            }
        }

        public TreeNode Insert(double value)
        {
            if (this == null)
            {
                return new TreeNode(value);
            }

            if (value < Width)
            {
                if (Left == null)
                {
                    Left = new TreeNode(value);
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else if (value > Width)
            {
                if (Right == null)
                {
                    Right = new TreeNode(value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
            else if(value == Width)
            {
                return this;
            }

            return this;
        }

        public TreeNode Remove(double width)
        {
            if (this == null)
            {
                return null;
            }
            if (width < Width)
            {
                if (Left != null)
                {
                    Left = Left.Remove(width);
                }
            }
            else if (width > Width)
            {
                if (Right != null)
                {
                    Right = Right.Remove(width);
                }
            }
            else
            {
                if (Left == null)
                {
                    return Right;
                }
                else if (Right == null)
                {
                    return Left;
                }
                else
                {
                    TreeNode temp = FindMin(Right);
                    Width = temp.Width;
                    Right = Right.Remove(temp.Width);
                }
            }
            return this;

        }

        public TreeNode FindMin(TreeNode tree)
        {
            while (tree.Left != null)
            {
                tree = tree.Left;
            }
            return tree;
        }

        public IEnumerable<TreeNode> BiggerValues(double value)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            BiggerValuesRecursive(this, value, nodes);
            return nodes;
        }

        //function that receive list, tree and value and add the all biggest values
        private void BiggerValuesRecursive(TreeNode node, double value, List<TreeNode> nodes)
        {
            if (node == null)
                return;

            if (node.Width >= value)
            {
                BiggerValuesRecursive(node.Left, value, nodes);
                nodes.Add(node);
                BiggerValuesRecursive(node.Right, value, nodes);
            }
            else
            {
                BiggerValuesRecursive(node.Right, value, nodes);
            }
        }


    }
}
