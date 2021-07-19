using System;
using System.Data;
using System.Threading;

// Row,Col representation
//0,0 0,1 0,2 0,3 0,4
//1,0             1,4  
//2,0             2,4 
//3,0             3,4 
//4,0 4,1 4,2 4,3 4,4
//
//6,0

namespace SetCursorPosition
{
    class Program
    {
        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private static void SetGreenText()
        {
             
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void SetWhiteText()
        {

            Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void Main()
        {
            // Clear the screen, then save the top and left coordinates.
            const string stringValue = "Mission Impossible ";
            // Version 1: use foreach-loop.
             
            foreach (char c in stringValue)
            {
                 
                Console.Write(c);

                int rowPos = Console.CursorTop;
                int colPos = Console.CursorLeft;

                if(colPos >=2)
                {
                    int prevCol = colPos - 2;
                    Console.SetCursorPosition(prevCol, rowPos);
                    SetGreenText();
                    char charInString = stringValue[prevCol];
                    Console.Write(charInString);
                    Console.SetCursorPosition(colPos  , rowPos);
                    SetWhiteText();
                }
                




                Thread.Sleep(150);
            }

            Console.WriteLine( );
            Console.WriteLine("Print any key to continue");
            Console.ReadLine( );

            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            

            // Draw the left side of a 5x5 rectangle, from top to bottom.
            WriteAt("+", 0, 0);
            WriteAt("|", 0, 1);
            WriteAt("|", 0, 2);
            WriteAt("|", 0, 3);
            WriteAt("+", 0, 4);

            // Draw the bottom side, from left to right.
            WriteAt("-", 1, 4); // shortcut: WriteAt("---", 1, 4)
            WriteAt("-", 2, 4); // ...
            WriteAt("-", 3, 4); // ...
            WriteAt("+", 4, 4);

            // Draw the right side, from bottom to top.
            WriteAt("|", 4, 3);
            WriteAt("|", 4, 2);
            WriteAt("|", 4, 1);
            WriteAt("+", 4, 0);

            // Draw the top side, from right to left.
            WriteAt("-", 3, 0); // shortcut: WriteAt("---", 1, 0)
            WriteAt("-", 2, 0); // ...
            WriteAt("-", 1, 0); // ...
                                //
            WriteAt("All done!", 0, 6);
            Console.WriteLine();

            Console.WriteLine("origRow " + origRow);
            Console.WriteLine("origCol " + origCol);

            Console.ReadLine();
        }
    }
    /*
    This example produces the following results:

    +---+
    |   |
    |   |
    |   |
    +---+

    All done!

    */
}
