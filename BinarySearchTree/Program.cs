using System;

// Reference :-
//https://www.youtube.com/watch?v=Blp-_YDojuA
// https://github.com/kc70x/BinaryTreeExample/blob/master/BinaryTreeExample/Program.cs

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree();

            /*
            bst.Insert(75); //root
            bst.Insert(57);
            bst.Insert(90);
            bst.Insert(32);
            bst.Insert(7);
            bst.Insert(44);
            bst.Insert(60);
            bst.Insert(86);
            bst.Insert(93);
            bst.Insert(99);
            bst.Insert(100);
            */

            // Test Data
            bst.Insert(25); //root
            bst.Insert(15);
            bst.Insert(10);
            bst.Insert(4);
            bst.Insert(12);
            bst.Insert(22);
            bst.Insert(18);
            bst.Insert(24);
            bst.Insert(50);
            bst.Insert(35);
            bst.Insert(31);
            bst.Insert(44);
            bst.Insert(70);
            bst.Insert(66);
            bst.Insert(90);

            // These 3 traversal can give a proper logical visualization of how the B Tree looks graphically
            Console.WriteLine("In Order Traversal (Left->Root->Right)");
            bst.InOrderTraversal();

            Console.WriteLine("\nPre Order Traversal (Root->Left->Right)");
            bst.PreorderTraversal();
            
            Console.WriteLine("\nPost Order Traversal (Left->Right->Root)");
            bst.PostorderTraversal();

            //

            Console.ReadLine();
        }


        public static int getHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(getHeight(root.LeftNode), getHeight(root.RightNode)) + 1;
        }

        public static bool isBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int heightDiff = getHeight(root.LeftNode) - getHeight(root.RightNode);
            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                return (isBalanced(root.LeftNode) && isBalanced(root.RightNode));
            }
        }


    }


}
