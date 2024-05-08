using System.Linq;

namespace BoxModels.Models
{
    public class HeightTree
    {
        public double Height { get; set; }
        public Box Boxes { get; set; }

        public static int AdditionlBoxes { get; set; }

        public HeightTree Left { get; set; }
        public HeightTree Right { get; set; }

        public HeightTree(double value)
        {

            Height = value;
            Left = null;
            Right = null;
        }


        public HeightTree Insert(double value,Box b)
        {
            if (this == null)
            {
                return new HeightTree(value);
            }

            if (value < Height)
            {
                if (Left == null)
                {
                    Left = new HeightTree(value);
                }
                else
                {
                    Left.Insert(value,b);

                }
            }
            else if (value > Height)
            {
                if (Right == null)
                {
                    Right = new HeightTree(value);
                }
                else
                {

                    Right.Insert(value,b);
                }
            }
            else if (value == Height)
            {

                        Boxes.Amount += b.Amount;
            }

            return this;
        }
        public HeightTree Search(double value)
        {
            if (this == null || value == Height)
            {
                return this;
            }
            if (Height > value)
            {
                return Left?.Search(value);
            }
            else
            {
                return Right?.Search(value);
            }
        }
        public HeightTree Remove(double height)
        {
            if (this == null)
            {
                return null;
            }
            if (height < Height)
            {
                if (Left != null)
                {
                    Left = Left.Remove(height);
                }
            }
            else if (height > Height)
            {
                if (Right != null)
                {
                    Right = Right.Remove(height);
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
                    HeightTree temp = FindMin(Right);
                    Height = temp.Height;
                    Right = Right.Remove(temp.Height);
                }

            }
            return this;
        }

        // create function that returns the min value in the tree
        public HeightTree FindMin(HeightTree tree)
        {
            while (tree.Left != null)
            {
                tree = tree.Left;
            }
            return tree;
        }

        // create function that receives height and remove one box with that height 
        public void RemoveBox(double height)
        {

            if (Boxes.Amount > 0)
            {
                    Boxes.Amount--;
            }
               
                    
                 

                
            
        }

    }
}
