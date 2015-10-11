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

        private const int HORIZONTAL_MARGIN = 5;
        private string _margin = new string(' ', HORIZONTAL_MARGIN);

        private const int VERTICAL_MARGIN = 3;

        private const string HEADER_TEXT = "Steal the prototype";

        private Player _player;
        private StaffList _staffList;
        private GuardList _guardList;
        private ZoneMaster _zoneMaster;

        #endregion


        #region [ METHODS ]
        public void DisplayClear()
        {
            Console.Clear();
        }

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

        public void DrawHeader()
        {
            Console.WriteLine("");

            string middleLine = new string(' ', ((WINDOW_WIDTH - HEADER_TEXT.Count()) / 2));
            middleLine = middleLine + HEADER_TEXT + middleLine;

            Console.WriteLine(middleLine);

            Console.WriteLine("");
        }

        public void DisplayInitialInformation()
        {
            DisplayPlayerInformation();
            DisplayPlayerGoal();
            DisplayPlayerInventory();
            DisplayCommands();
            DisplayRoomInformation();
        }

        public void DisplayCommands()
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + "Valid commands are: ");
            foreach (GameController.Commands command in Enum.GetValues(typeof(GameController.Commands)))
            {
                Console.WriteLine(_margin + command.ToString());
            }

        }

        public void DisplayPlayerInformation()
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + "You are {0}, a {1} {2}.",
                _player.Name,
                _player.Gender,
                _player.Race);
        }

        public void DisplayPlayerGoal()
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + "Your objective is to steal a prototype from the secret lab in this building.");
        }

        public void DisplayPlayerInventory()
        {
            Console.WriteLine("");

            if (_player.Inventory.Count == 0)
                Console.WriteLine(_margin + "Your inventory is empty.");
            else
            {
                foreach (Item i in _player.Inventory)
                {
                    Console.WriteLine(_margin + i.Name);
                    Console.WriteLine(_margin + "\t" + i.Description);
                }
            }
        }

        public void DisplayRoomInformation()
        {
            Console.WriteLine("");

            Console.WriteLine(_margin + _zoneMaster.Rooms[_player.CurrentRoom[0], _player.CurrentRoom[1]].Desciption);

            foreach (Guard g in _guardList.Guards)
            {
                if (g.CurrentRoom == _player.CurrentRoom)
                {
                    Console.WriteLine(_margin + "Guard: {0}", g.Name);
                }
            }

            foreach (Staff s in _staffList.Staff)
            {
                if (s.CurrentRoom == _player.CurrentRoom)
                {
                    Console.WriteLine(_margin + "Staff: {0}", s.Name);
                }
            }
        }

        public GameController.Commands GetPlayerCommand()
        {
            GameController.Commands output = GameController.Commands.wait;

            bool validInput = false;

            while (!validInput)
            {
                string input = Console.ReadLine();
                GameController.Commands command;
                if(Enum.TryParse<GameController.Commands>(input,true,out command))
                {
                    output = command;
                    validInput = true;
                }

                else
                {
                    Console.WriteLine("I didn't understand that,  try again");
                }
            }


            return output;
        }

        public string GetPlayerSubject(GameController.Commands command)
        {
            string output = "";

            switch (command)
            {
                case GameController.Commands.go:

                    Console.WriteLine("Go where?");
                    string directionInput = Console.ReadLine();
                    ZoneMaster.Directions direction;
                    if (Enum.TryParse<ZoneMaster.Directions>(directionInput, true, out direction))
                    {
                        output = direction.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Thats not a direction");
                    }
                    break;

                case GameController.Commands.look:

                    Console.WriteLine("Look at what?");
                    string targetInput = Console.ReadLine().ToLower();
                    string[] self = { "me", "myself" };
                    string[] guards;
                    string[] staff;

                    #region Getting subjects
                    {
                        List<Guard> guardList = new List<Guard>();
                        foreach (Guard g in _guardList.Guards)
                        {
                            if (g.CurrentRoom == _player.CurrentRoom)
                            {
                                guardList.Add(g);
                            }
                        }
                        guards = new string[guardList.Count];
                        for (int i = 0; i < guardList.Count; i++)
                        {
                            guards[i] = guardList.ElementAt(i).Name.ToLower();
                        }
                    }

                    {
                        List<Staff> staffList = new List<Staff>();
                        foreach (Staff s in _staffList.Staff)
                        {
                            if (s.CurrentRoom == _player.CurrentRoom)
                            {
                                staffList.Add(s);
                            }
                        }
                        staff = new string[staffList.Count];
                        for (int i = 0; i < staffList.Count; i++)
                        {
                            staff[i] = staffList.ElementAt(i).Name.ToLower();
                        }
                    }
                    #endregion

                    if (self.Contains(targetInput))
                    {
                        output = "I look awesome, obviously.";
                    }
                    else if (guards.Contains(targetInput))
                    {
                        foreach (Guard g in _guardList.Guards)
                        {
                            if (g.Name == targetInput)
                                output = g.Decription();
                        }
                    }
                    else if (staff.Contains(targetInput))
                    {
                        foreach (Staff s in _staffList.Staff)
                        {
                            if (s.Name == targetInput)
                                output = s.Decription();
                        }
                    }
                    else
                    {
                        output = string.Format("There is no {0} here", targetInput);
                    }


                    break;
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

        public void DisplayMessage(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(_margin + message);
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
