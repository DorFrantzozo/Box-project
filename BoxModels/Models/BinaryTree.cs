using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxModels.Models
{
    public static class BinaryTree
    {


        
        public static TreeNode root = null;

        public static TreeNode AddBox(double width, double height, int amount)
        {

            if (root == null || root.Width == 0)
            {
                root = new TreeNode(width);
                root.HeightTr = new HeightTree(height);
                root.HeightTr.Boxes = (new Box(width, height, amount));
            }
            else
            {
                root.Insert(width);
                TreeNode scanRoot = root.Search(width);
                if (scanRoot.HeightTr == null)
                {
                    scanRoot.HeightTr = new HeightTree(height);
                    scanRoot.HeightTr.Boxes = (new Box(width, height, amount));
                }
                else
                {
                    HeightTree h = scanRoot.HeightTr.Insert(height, new Box(width, height, amount));
                    HeightTree tree = h.Search(height);
                   
                }


            }
            Stock.SaveToFile();
            return root;
        }

        private static HeightTree FindClosetBiggerValue(double value, double percentage, HeightTree tree)
        {
            HeightTree closetBiggerValue = null;
            while (tree != null)
            {
                if (tree.Height >= value)
                {
                    if (IsInDeviationRange(tree.Height, value, percentage))
                    {
                        closetBiggerValue = tree;
                    }
                    tree = tree.Left;

                }
                else
                {
                    tree = tree.Right;
                }
            }
            return closetBiggerValue;
        }
        private static TreeNode FindClosetBiggerValue(double value, double percentage, TreeNode tree)
        {
            TreeNode closetBiggerValue = null;
            while (tree != null)
            {
                if (tree.Width >= value)
                {
                    if (IsInDeviationRange(tree.Width, value, percentage))
                    {
                        closetBiggerValue = tree;
                    }
                    tree = tree.Left;
                }
                else
                {
                    tree = tree.Right;
                }
            }
            return closetBiggerValue;
        }
        private static bool IsInDeviationRange(double value, double originalValue, double percentage)
        {
            double range = percentage / 100 + 1;
            return originalValue * range >= value && !(value < originalValue);
        }
        public static void InOrderTraversal()
        {
            InOrderTraversal();
        }

        private static void InOrderTraversal(HeightTree root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Height + " ");
                InOrderTraversal(root.Right);
            }
        }
        private static void ScanHeightTree(HeightTree heightTree, List<Box> listBox)
        {
            if (heightTree != null)
            {
               
                    listBox.Add(heightTree.Boxes);
                
                ScanHeightTree(heightTree.Left, listBox);
                ScanHeightTree(heightTree.Right, listBox);
            }
        }
        private static List<Box> GetAllBoxes(TreeNode tree)
        {
            List<Box> boxes = new List<Box>();
            if (tree != null)
            {
                ScanHeightTree(tree.HeightTr, boxes);
                List<Box> leftBoxes = GetAllBoxes(tree.Left);
                boxes.AddRange(leftBoxes);
                List<Box> rightBoxes = GetAllBoxes(tree.Right);
                boxes.AddRange(rightBoxes);
            }
            return boxes;
        }
        public static List<Box> GetBoxes()
        {
            if (Stock.LoadTree() != null)
                root = Stock.LoadTree();
            return GetAllBoxes(root);
        }

        public static List<Box> FindBoxes(double width, double height, int amount)
        {
            List<Box> boxes = new List<Box>();
            TreeNode closetBiggerWidth = FindClosetBiggerValue(width, 40, root);
            while (closetBiggerWidth != null && boxes.Count < amount)
            {
                HeightTree closetBiggerHeight = FindClosetBiggerValue(height, 40, closetBiggerWidth.HeightTr);
                if (closetBiggerHeight != null)
                {
                    Box box = closetBiggerHeight.Boxes;
                    if (box != null)
                    {
                        
                        boxes.Add(box);
                        closetBiggerHeight.RemoveBox(box.Height);
                       // closetBiggerHeight.Boxes.Remove(box);
                    }
                    if (closetBiggerHeight.Boxes.Amount == 0)
                    {
                        closetBiggerWidth = FindClosetBiggerValue(width, 40, root);
                        if (closetBiggerWidth != null)
                        {
                            closetBiggerWidth.HeightTr = closetBiggerWidth.HeightTr.Remove(closetBiggerHeight.Height);
                            if (closetBiggerWidth.HeightTr == null)
                            {
                                root = root.Remove(closetBiggerWidth.Width);
                            }
                        }
                    }
                }
                else
                {
                    closetBiggerWidth = root.BiggerValues(closetBiggerWidth.Width +1 ).FirstOrDefault(node => node.HeightTr != null && node.HeightTr.Boxes.Amount > 0);
                    
                }
            }

            return boxes;
        }


    }







}


