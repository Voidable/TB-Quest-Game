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
        //  Window dimensions
        private const int WINDOW_WIDTH = 100;
        private const int WINDOW_HEIGHT = 40;

        //  Horizontal margin
        private const int HORIZONTAL_MARGIN = 5;
        private string _margin = new string(' ', HORIZONTAL_MARGIN);

        //  Vertical margin
        private const int VERTICAL_MARGIN = 3;

        //  Header text
        private const string HEADER_TEXT = "Steal the prototype";

        //  Object refrences
        private Player _player;
        private StaffList _staffList;
        private GuardList _guardList;
        private ZoneMaster _zoneMaster;

        #endregion


        #region [ METHODS ]
        /// <summary>
        /// Clears the window
        /// </summary>
        public void DisplayClear()
        {
            Console.Clear();
            DrawHeader();
        }

        /// <summary>
        /// The program's welcome screen
        /// </summary>
        public void DisplayGreeting()
        {
            DrawHeader();

            for (int i = 0; i < VERTICAL_MARGIN; i++)
            {
                Console.WriteLine("");
            }

            Console.WriteLine(_margin + "Welcome to the game \"" + HEADER_TEXT + "\"");
            Console.WriteLine(_margin + "Type \"Play\" to continue, or \"Exit\" to quit");
        }

        /// <summary>
        /// Draws the header on the top the window, centering the header text
        /// </summary>
        public void DrawHeader()
        {
            Console.WriteLine("");

            string middleLine = new string(' ', ((WINDOW_WIDTH - HEADER_TEXT.Count()) / 2));
            middleLine = middleLine + HEADER_TEXT + middleLine;

            Console.WriteLine(middleLine);

            Console.WriteLine("");
        }

        /// <summary>
        /// Displays the intitial information.
        /// </summary>
        public void DisplayInitialInformation()
        {
            DisplayPlayerInformation();
            DisplayPlayerGoal();
            DisplayPlayerInventory();
            DisplayCommands();
            DisplayRoomInformation();
        }

        /// <summary>
        /// Displays all valid commands
        /// </summary>
        public void DisplayCommands()
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + "Valid commands are: ");
            //  Iterate through each value in the Enum and write to window
            foreach (GameController.Commands command in Enum.GetValues(typeof(GameController.Commands)))
            {
                Console.WriteLine(_margin + command.ToString());
            }

        }

        /// <summary>
        /// Tells the player about themself
        /// </summary>
        public void DisplayPlayerInformation()
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + "You are {0}, a {1} {2}.",
                _player.Name,
                _player.Gender,
                _player.Race);
        }

        /// <summary>
        /// Tell the player their goal
        /// </summary>
        public void DisplayPlayerGoal()
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + "Your objective is to steal a prototype from the secret lab in this building.");
        }

        /// <summary>
        /// Displays the player's inventory
        /// </summary>
        public void DisplayPlayerInventory()
        {
            Console.WriteLine("");

            if (_player.Inventory.Count == 0)   //  Empty inventory
                Console.WriteLine(_margin + "Your inventory is empty.");
            else
            {
                foreach (Item i in _player.Inventory)   //  Iterate through the inventory, naming and describing everything
                {
                    Console.WriteLine(_margin + i.Name);
                    Console.WriteLine(_margin + "\t" + i.Description);
                }
            }
        }

        /// <summary>
        /// Displays information about the current room
        /// </summary>
        public void DisplayRoomInformation()
        {
            Console.WriteLine("");

            //  Describes the room
            Console.WriteLine(_margin + _zoneMaster.Rooms[_player.CurrentRoom[0], _player.CurrentRoom[1]].Desciption);

            // Tell the player about all the guards
            foreach (Guard g in _guardList.Guards)
            {
                if (g.CurrentRoom[0] == _player.CurrentRoom[0] & g.CurrentRoom[1] == _player.CurrentRoom[1])
                {
                    Console.WriteLine(_margin + "Guard: {0}", g.Name);
                }
            }

            //  Tell the player about all the staff
            foreach (Staff s in _staffList.Staff)
            {
                if (s.CurrentRoom[0] == _player.CurrentRoom[0] & s.CurrentRoom[1] == _player.CurrentRoom[1])
                {
                    Console.WriteLine(_margin + "Staff: {0}", s.Name);
                }
            }
        }

        /// <summary>
        /// Gets input from the player, parsing to a valid command
        /// </summary>
        /// <returns></returns>
        public GameController.Commands GetPlayerCommand()
        {
            //  create holder, initial value is wait
            GameController.Commands output = GameController.Commands.wait;

            bool validInput = false;

            while (!validInput) //  Loop until the player enter's valid input
            {
                string input = Console.ReadLine();  //  Get input

                GameController.Commands command;  //  Parse input string to enum
                if (Enum.TryParse<GameController.Commands>(input,true,out command)) //  Valid input
                {
                    output = command;
                    validInput = true;
                }

                else
                {
                    //  Invalid input
                }
                {
                    Console.WriteLine("I didn't understand that,  try again");
                }
            }


            return output;
        }

        /// <summary>
        /// Elaborates on the player command, writing the results of command to window
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string GetPlayerSubject(GameController.Commands command)
        {
            string output = "";

            switch (command)    //  Switch based on inputed command
            {
                case GameController.Commands.go:    //  Player wants to go somewhere

                    Console.WriteLine("Go where?"); //  Prompt player for direction
                    string directionInput = Console.ReadLine(); 

                    ZoneMaster.Directions direction;    //  Parse direction to valid direction
                    if (Enum.TryParse<ZoneMaster.Directions>(directionInput, true, out direction))  //  Successfull parse
                    {
                        output = direction.ToString();  //  Return direction as string
                    }
                    else   //   Invalid input
                    {
                        Console.WriteLine("Thats not a direction");
                    }
                    break;

                case GameController.Commands.look:  //  Player wants to look at something

                    Console.WriteLine("Look at what?"); //  Prompt player for clarification
                    string targetInput = Console.ReadLine().ToLower();

                    //  Create string array's of valid  objects to look at
                    string[] self = { "me", "myself" };
                    string[] guards;
                    string[] staff;

                    #region Getting subjects
                    {   //  Get all the guards

                        List<Guard> guardList = new List<Guard>();
                        foreach (Guard g in _guardList.Guards)
                        {   //  If a guard is in the same room as the player, add them to the list
                            if (g.CurrentRoom[0] == _player.CurrentRoom[0] & g.CurrentRoom[1] == _player.CurrentRoom[1])
                            {
                                guardList.Add(g);
                            }
                        }
                        guards = new string[guardList.Count];   //  Add the guard's name from the list to the array
                        for (int i = 0; i < guardList.Count; i++)
                        {
                            guards[i] = guardList.ElementAt(i).Name.ToLower();
                        }
                    }


                    {   //  Get all the staff

                        List<Staff> staffList = new List<Staff>();
                        foreach (Staff s in _staffList.Staff)
                        {   //  If a staff is in the same room as the player, add them to the list
                            if (s.CurrentRoom[0] == _player.CurrentRoom[0] & s.CurrentRoom[1] == _player.CurrentRoom[1])
                            {
                                staffList.Add(s);
                            }
                        }
                        staff = new string[staffList.Count];    //  Add the staff's name from the list to the array
                        for (int i = 0; i < staffList.Count; i++)
                        {
                            staff[i] = staffList.ElementAt(i).Name.ToLower();
                        }
                    }
                    #endregion

                    if (self.Contains(targetInput)) //  Player says "me" or "myself"
                    {
                        output = "I look awesome, obviously.";
                    }
                    else if (guards.Contains(targetInput))  //  Player says name of guard
                    {
                        foreach (Guard g in _guardList.Guards)
                        {
                            if (g.Name.ToLower() == targetInput)
                                output = g.Decription();
                        }
                    }
                    else if (staff.Contains(targetInput))   //  Player says name of staff
                    {
                        foreach (Staff s in _staffList.Staff)
                        {
                            if (s.Name.ToLower() == targetInput)
                                output = s.Decription();
                        }
                    }
                    else   //   Player says something that is not there
                    {
                        output = string.Format("There is no {0} here", targetInput);
                    }


                    break;

                    //  The remaining commands don't need clarification

                case GameController.Commands.play:
                    output = "play";
                    break;
                case GameController.Commands.quit:
                    output = "quit";
                    break;
                case GameController.Commands.wait:
                    output = "wait";
                    break;
            }

            return output;
        }

        /// <summary>
        /// Writes a message to the window
        /// </summary>
        /// <param name="message"></param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + message);
        }
        #endregion


        #region [ CONSTRUCTORS ]

        /// <summary>
        /// Constructs the consoleView
        /// </summary>
        /// <param name="player"></param>
        /// <param name="stafflist"></param>
        /// <param name="guardlist"></param>
        /// <param name="zonemaster"></param>
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
