// Program that uses a tree to create a 20 questions game
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

                Console.WriteLine("\nWould you like to play again? yes or no?");
                string answer = Console.ReadLine().ToLower();

                playAgain = answer == "yes";
            } while (playAgain);

            Console.WriteLine("Thanks for playing!");
        }

        //added in the Traverse of the Tree
        //learning functionallity
        static void TraverseTree(TreeNode node)
        {

            //To keep track or the parent 
            TreeNode parent = null;
            bool isLeft = false;

            //run until nodes run out
            while (node != null)
            {
                //conditional when both left and right are null, ends whilrloop and allows program to learn
                if (node.Left == null && node.Right == null)
                {
                    Console.WriteLine(node.Data);
                    Console.Write("Was the guess correct? (yes or no): ");
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "yes")
                    {
                        Console.WriteLine("Yay! Thanks for playing");
                        return;
                    }
                    // user and add the question and answer
                    else if (answer == "no")
                    {
                        Console.Write("What were you thinking of? ");
                        string correctAnswer = Console.ReadLine();

                        Console.Write("Please provide a yes/no question that distinguishes your answer from mine: ");
                        string newQuestion = Console.ReadLine();

                        Console.Write($"For your answer '{correctAnswer}', what would the correct response be to your question? (yes or no): ");
                        string correctResponse = Console.ReadLine().ToLower();

                        // Create new nodes
                        TreeNode correctNode = new TreeNode($"It's a {correctAnswer}!");
                        TreeNode incorrectNode = new TreeNode(node.Data);

                        node.Data = newQuestion;
                        if (correctResponse == "yes")
                        {
                            node.Left = correctNode;
                            node.Right = incorrectNode;
                        }
                        else
                        {
                            node.Left = incorrectNode;
                            node.Right = correctNode;
                        }

                        Console.WriteLine("Thank you for your input!");
                        return;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. Plese enter 'yes' or 'no'.");
                    }

                }

                //else if either node have a value
                else
                {
                    parent = node;
                    Console.WriteLine(node.Data);
                    Console.Write("yes or no?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        node = node.Left;
                        isLeft = true;
                    }
                    else if (answer == "no")
                    {
                        node = node.Right;
                        isLeft = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Plese enter 'yes' or 'no'.");
                    }
                }

            }
        }
    }
}
