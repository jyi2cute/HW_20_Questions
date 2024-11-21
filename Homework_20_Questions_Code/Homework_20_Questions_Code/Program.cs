namespace Homework_20_Questions_Code
{
    internal class Program
    {
        class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public string Data { get; set; }

            public TreeNode(string data)
            {
                Left = null;
                Right = null;
                Data = data;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the 20 Questions Game!");
            Console.WriteLine("Think of something, and I'll try to guess it.");


            

            // root of tree
            TreeNode root = new TreeNode("Is it an animal?");
            // if the answer is yes, move left. If the answer is no, move right

            // left side of tree (yes)
            root.Left = new TreeNode("Does it have four legs?");
            root.Left.Left = new TreeNode("Is it a pet?");
            root.Left.Left.Left = new TreeNode("It's a dog!");
            root.Left.Left.Right = new TreeNode("It's a horse!");
            root.Left.Right = new TreeNode("Does it fly?");
            root.Left.Right.Left = new TreeNode("It's a bird!");
            root.Left.Right.Right = new TreeNode("It's a fish!");

            // right side of tree (no)
            root.Right = new TreeNode("Is it a vehicle?");
            root.Right.Left = new TreeNode("Is it a car?");
            root.Right.Right = new TreeNode("Is it a building?");

            //repeating, multiple rounds
            bool playAgain;
            do
            {
                TraverseTree(root);

                Console.WriteLine("\nWould you like to play again? Yes or No?");
                string answer = Console.ReadLine().ToLower();

                playAgain = answer == "yes";
            } while (playAgain);

            Console.WriteLine("Thanks for playing!");
        }

        //added in the Traverse of the Tree
        static void TraverseTree(TreeNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Data);
                Console.Write("Yes or No?");
                string answer = Console.ReadLine().ToLower();

                if (answer == "yes")
                {
                    node = node.Left;
                } else if (answer == "no")
                {
                    node = node.Right;
                }
                else
                {
                    Console.WriteLine("Invalid input. Plese enter 'Yes' or 'No'.");
                }
            }
        }
    }
}
