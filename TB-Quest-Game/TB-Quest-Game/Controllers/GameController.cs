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
        /// Enumaration of all current commands
        /// </summary>
        public enum Commands
        {
            go,
            look,
            play,
            quit,
            wait
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
        /// Creates the player, defaults to Bob
        /// </summary>
        public void InitializePlayer()
        {
            _myPlayer = new Player("Bob", Person.Genders.Male, Person.Races.Human);
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
            InitializePlayer();
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
            ConsoleView viewWindow = new ConsoleView(_myPlayer, _staffList, _guardList, _zoneMaster);

            //  Display the greeting
            viewWindow.DisplayGreeting();


            bool validInput = false;
            bool playingGame = false;

            while (!validInput)
            {
                //  Get input from players
                Commands command = viewWindow.GetPlayerCommand();

                if (command == Commands.play)   //  Player wants to play the game
                {
                    playingGame = true;
                    validInput = true;
                }

                else if (command == Commands.quit)  //  Player wants to quit the game
                {
                    playingGame = false;
                    validInput = true;
                }
                else   //   Player has entered an invalid command
                {
                    viewWindow.DisplayClear();
                    viewWindow.DisplayGreeting();
                }
            }

            bool initialPrompt = true;

            while (playingGame) // While playing the game, loop through the core logic
            {
                if (initialPrompt)  //  Display the initial prompt if we havent before
                {
                    viewWindow.DisplayInitialInformation();
                    initialPrompt = false;
                }

                //  Get command from player
                Commands command = viewWindow.GetPlayerCommand();

                if (command == Commands.go) //  Player wants to go somewhere
                {
                    //  Get the direction the player wants to travel, parsing the player's input to the Diretion type enum.
                    ZoneMaster.Directions direction = (ZoneMaster.Directions)Enum.Parse(typeof(ZoneMaster.Directions), viewWindow.GetPlayerSubject(command));

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
                else if (command == Commands.look)  //  Player wants to look at something
                {
                    viewWindow.DisplayMessage(viewWindow.GetPlayerSubject(command));    //  Get the subject matter
                }
                else if (command == Commands.wait)  //  Player wants to do something
                {
                    viewWindow.DisplayMessage("I'll wait here for a second");
                }
                else if(command == Commands.quit)   //  Player wants to exit
                {
                    playingGame = false;
                }
                else   //   This currently catches any unavailable commands, like the play command
                {
                    viewWindow.DisplayMessage("I cant do that right now.");
                }

            }


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
