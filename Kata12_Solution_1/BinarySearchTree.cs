using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Kata12_Solution_1
{
    public class BinaryTreeNode 
    {
        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public int Data { get; set; }
    }

    public class BinarySearchTree
    {
        public BinaryTreeNode Root { get; set; }

        public bool Add(int value)
        {
            BinaryTreeNode before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.Left;
                else if (value > after.Data) 
                    after = after.Right;
                else
                {
                    return false;
                }
            }

            BinaryTreeNode newNode = new BinaryTreeNode();
            newNode.Data = value;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.Left = newNode;
                else
                    before.Right = newNode;
            }

            return true;
        }

        public BinaryTreeNode Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private BinaryTreeNode Remove(BinaryTreeNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.Left = Remove(parent.Left, key);
            else if (key > parent.Data)
                parent.Right = Remove(parent.Right, key);
 
            else
            {
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;

                parent.Data = MinValue(parent.Right);
                parent.Right = Remove(parent.Right, parent.Data);
            }

            return parent;
        }

        private int MinValue(BinaryTreeNode node)
        {
            int minv = node.Data;

            while (node.Left != null)
            {
                minv = node.Left.Data;
                node = node.Left;
            }

            return minv;
        }

        private BinaryTreeNode Find(int value, BinaryTreeNode parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.Left);
                else
                    return Find(value, parent.Right);
            }

            return null;
        }
    }
}
