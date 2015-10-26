using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class GameController
    {
        /// <summary>
        /// Enumeration of all current commands
        /// </summary>
        public enum Commands
        {
            Go,
            Look,
            Play,
            Quit,
            Wait,
            Help
        }

        #region [ FIELDS ]
        //  Reference to the player object
        Player _myPlayer;

        //  Reference to ZoneMaster, which holds and controls all rooms
        ZoneMaster _zoneMaster;

        //  Reference to the Guard list, which holds and creates the guards
        GuardList _guardList;

        //  Reference to the Staff list, which holds and creates the staff
        StaffList _staffList;

        #endregion



        #region [ METHODS ]

        /// <summary>
        /// Creates the player from inputs
        /// </summary>
        public void InitializePlayer(string name, Person.Genders gender, Person.Races race)
        {
            _myPlayer = new Player(name, gender, race);
            _myPlayer.CurrentRoom[0] = 0;
            _myPlayer.CurrentRoom[1] = 0;
        }

        /// <summary>
        /// Creates the Zonemaster and initializes the rooms
        /// </summary>
        public void InitializeZoneMaster()
        {
            _zoneMaster = new ZoneMaster();
            _zoneMaster.InitializeRooms();
        }

        /// <summary>
        /// Creates the Guardlist and initializes the guards
        /// </summary>
        public void InitializeGuardList()
        {
            _guardList = new GuardList();
            _guardList.InitializeGuards();
        }

        /// <summary>
        /// Creates the Stafflist and initializes the staff
        /// </summary>
        public void InitializeStaffList()
        {
            _staffList = new StaffList();
            _staffList.InitializeStaff();
        }

        /// <summary>
        /// Sets up the game, initializing the player, zonemaster,guardlist, and staff list
        /// </summary>
        public void SetupGame()
        {
            InitializeZoneMaster();
            InitializeGuardList();
            InitializeStaffList();
        }

        /// <summary>
        /// Handles the Game logic
        /// </summary>
        public void PlayGame()
        {
            //  Create the view window
            ConsoleView viewWindow = new ConsoleView(_staffList, _guardList, _zoneMaster);

            #region Main Menu

            //  Display the greeting
            viewWindow.DisplayGreeting();


            bool validInput = false;
            bool playingGame = false;

            #region Main-Menu Input Loop
            while (!validInput)
            {
                //  Get input from players
                Commands command = viewWindow.GetPlayerCommand();

                if (command == Commands.Play)   //  Player wants to play the game
                {
                    playingGame = true;
                    validInput = true;
                }

                else if (command == Commands.Quit)  //  Player wants to quit the game
                {
                    playingGame = false;
                    validInput = true;
                }
                else   //   Player has entered an invalid command
                {
                    viewWindow.DisplayMessage("That is not a valid command!");
                }
            }
            #endregion

            #endregion

            if (playingGame)
            {
                #region Create-Player Menu

                #region Race
                bool validRace = false;
                Person.Races race = Person.Races.Human;

                while (!validRace)
                {
                    //  Clear the window
                    viewWindow.DisplayClear();

                    //  Prompt user for their race
                    viewWindow.DisplayMessage("What race are you?\n");
                    viewWindow.DisplayValidRaces();
                    string input = viewWindow.GetPlayerNoun("");

                    if (Enum.TryParse<Person.Races>(input, true, out race))
                    {
                        validRace = true;
                    }

                    else
                    {
                        viewWindow.DisplayMessage("That didn't make sense, try again.");
                        viewWindow.WaitForPlayer();
                    }
                }
                #endregion
                #region Gender
                bool validGender = false;
                Person.Genders gender = Person.Genders.Male;

                while (!validGender)
                {
                    //  Clear the window
                    viewWindow.DisplayClear();

                    //  Prompt user for their race
                    viewWindow.DisplayMessage("What Gender are you?\n");
                    viewWindow.DisplayValidGenders();
                    string input = viewWindow.GetPlayerNoun("");

                    if (Enum.TryParse<Person.Genders>(input, true, out gender))
                    {
                        validGender = true;
                    }

                    else
                    {
                        viewWindow.DisplayMessage("That didn't make sense, try again.");
                        viewWindow.WaitForPlayer();
                    }
                }
                #endregion
                #region Name

                string name = "";
                bool validName = false;

                while (!validName)
                {
                    viewWindow.DisplayClear();
                    name = viewWindow.GetPlayerNoun("\n\tWhat is your name?");

                    string correct = viewWindow.GetPlayerNoun("\n\tAre you sure? Y/N");

                    if (correct.ToUpper() == "Y" || correct.ToUpper() == "YES")
                    {
                        validName = true;
                    }
                    else if (correct.ToUpper() == "N" || correct.ToUpper() == "NO")
                    {
                        viewWindow.WaitForPlayer();
                    }
                    else
                    {
                        viewWindow.DisplayMessage("Please enter \'Y\' for yes, or \'N\' for no");
                        viewWindow.WaitForPlayer();
                    }
                }

                #endregion

                //  Create the player with the entered values
                InitializePlayer(name, gender, race);

                // Pass the player to the viewWindow
                viewWindow.CreatePlayerReference(_myPlayer);

                #endregion

                #region Initial prompt;

                viewWindow.DisplayInitialInformation();

                #endregion

            }

            #region Game-logic loop
            while (playingGame) // While playing the game, loop through the core logic
            {
                //  Get command from player
                Commands command = viewWindow.GetPlayerCommand();

                #region Go command
                if (command == Commands.Go) //  Player wants to go somewhere
                {
                    // Get the direction player wants to travel, parsing input from console
                    ZoneMaster.Directions direction;    // Direction holder

                    if (!   //  If the input is not parsible to a direction, error message!
                        (Enum.TryParse<ZoneMaster.Directions>
                            (viewWindow.GetPlayerNoun("What direction would you like to go?"),
                            true, out direction)))
                    {
                        viewWindow.DisplayMessage("That's not a valid direction!");
                    }
                    else   // Input successfully parsed
                    {
                        //  Check's if the desired move is valid
                        if (_zoneMaster.CheckValidMove(direction, _myPlayer.CurrentRoom[0], _myPlayer.CurrentRoom[1]))  //  Valid move
                        {
                            //  Get the new coordinates from the Zonemaster
                            int[] coords = _zoneMaster.MoveCoords(direction, _myPlayer.CurrentRoom[0], _myPlayer.CurrentRoom[1]);

                            //  Set the players coords to the new coords
                            _myPlayer.CurrentRoom = coords;

                            //  Display the room information
                            viewWindow.DisplayRoomInformation();
                        }
                        else   //   Invalid move
                        {
                            viewWindow.DisplayMessage("You cannot go that way!");
                        }
                    }
                }
                #endregion
                #region Look command
                else if (command == Commands.Look)  //  Player wants to look at something
                {
                    //  Prompt player for clarification
                    string targetInput = viewWindow.GetPlayerNoun("Look at what?");

                    //  Create string array's of valid  objects to look at
                    string[] self = { "me", "myself" };
                    string[] guards;
                    string[] staff;

                    #region Getting subjects
                    {   //  Get all the guards

                        List<Guard> guardList = new List<Guard>();
                        foreach (Guard g in _guardList.Guards)
                        {   //  If a guard is in the same room as the player, add them to the list
                            if (g.CurrentRoom[0] == _myPlayer.CurrentRoom[0] & g.CurrentRoom[1] == _myPlayer.CurrentRoom[1])
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
                            if (s.CurrentRoom[0] == _myPlayer.CurrentRoom[0] & s.CurrentRoom[1] == _myPlayer.CurrentRoom[1])
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
                        viewWindow.DisplayMessage("I look awesome, obviously!");
                    }
                    else if (guards.Contains(targetInput))  //  Player says name of guard
                    {
                        foreach (Guard g in _guardList.Guards)
                        {
                            if (g.Name.ToLower() == targetInput)
                                viewWindow.DisplayMessage(g.Decription());
                        }
                    }
                    else if (staff.Contains(targetInput))   //  Player says name of staff
                    {
                        foreach (Staff s in _staffList.Staff)
                        {
                            if (s.Name.ToLower() == targetInput)
                                viewWindow.DisplayMessage(s.Decription());
                        }
                    }
                    else   //   Player says something that is not there
                    {
                        viewWindow.DisplayMessage(string.Format("There is no {0} here", targetInput));
                    }
                }
                #endregion
                #region Wait command
                else if (command == Commands.Wait)  //  Player wants to do something
                {
                    viewWindow.DisplayMessage("I'll wait here for a second");
                }
                #endregion
                #region Quit command
                else if (command == Commands.Quit)   //  Player wants to exit
                {
                    playingGame = false;
                }
                #endregion
                #region Help command
                else if (command == Commands.Help)
                {
                    viewWindow.DisplayCommands();
                }
                #endregion
                #region Unavailable command
                else   //   This currently catches any unavailable commands, like the play command
                {
                    viewWindow.DisplayMessage("I cant do that right now.");
                }
                #endregion

            }

            #endregion

            // Thank the player, close the program
            viewWindow.DisplayMessage("Thank you for playing!");
            viewWindow.WaitForPlayer();
        }

        #endregion


        #region [ CONSTRUCTORS ]

        /// <summary>
        /// Constructs the GameController and starts the game
        /// </summary>
        public GameController()
        {
            SetupGame();

            PlayGame();
        }

        #endregion
    }
}
