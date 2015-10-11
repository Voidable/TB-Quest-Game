using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class ConsoleView
    {
        #region [ FIELDS ]
        private const int WINDOW_WIDTH = 100;
        private const int WINDOW_HEIGHT = 40;

        private const int HORIZONTAL_MARGIN = 3;
        private string _margin = new string(' ', HORIZONTAL_MARGIN);

        private const int VERTICAL_MARGIN = 2;

        private const string HEADER_TEXT = "Steal the prototype";

        private Player _player;
        private StaffList _staffList;
        private GuardList _guardList;
        private ZoneMaster _zoneMaster;

        #endregion


        #region [ METHODS ]

        public void DisplayGreeting()
        {
            DrawHeader();

            for (int i = 0; i < VERTICAL_MARGIN; i++)
            {
                Console.WriteLine("");
            }

            Console.WriteLine(_margin + "Welcome to the game \"" + HEADER_TEXT + "\"");
            Console.WriteLine(_margin + "Type \"Play\" to continue, or \"Exit\" to quit");

            bool validInput = false;

            while(!validInput)
            {
                string input = Console.ReadLine().ToUpper();

                if (input == "PLAY")
                {

                }

                else if (input == "QUIT")
                {

                }
                else
                {

                }
            }
        }

        public void DrawHeader()
        {
            Console.WriteLine("");

            string middleLine =  new string(' ', ((WINDOW_WIDTH - HEADER_TEXT.Count()) / 2));
            middleLine = middleLine + HEADER_TEXT + middleLine;

            Console.WriteLine(middleLine);

            Console.WriteLine("");
        }

        #endregion


        #region [ CONSTRUCTORS ]

        public ConsoleView(Player player, StaffList stafflist, GuardList guardlist, ZoneMaster zonemaster)
        {
            Console.WindowHeight = WINDOW_HEIGHT;
            Console.WindowWidth = WINDOW_WIDTH;

            _player = player;
            _staffList = stafflist;
            _guardList = guardlist;
            _zoneMaster = zonemaster;
        }

        #endregion
    }
}
