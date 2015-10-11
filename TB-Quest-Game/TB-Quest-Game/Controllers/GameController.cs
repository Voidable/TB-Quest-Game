using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class GameController
    {
        public enum Commands
        {
            go,
            look,
            play,
            quit,
            wait
        }

        #region [ FIELDS ]

        Player _myPlayer;
        ZoneMaster _zoneMaster;
        GuardList _guardList;
        StaffList _staffList;

        #endregion



        #region [ METHODS ]

        public void InitializePlayer()
        {
            _myPlayer = new Player("Bob", Person.Genders.Male, Person.Races.Human);
            _myPlayer.CurrentRoom[0] = 0;
            _myPlayer.CurrentRoom[1] = 0;
        }

        public void InitializeZoneMaster()
        {
            _zoneMaster = new ZoneMaster();
            _zoneMaster.InitializeRooms();
        }

        public void InitializeGuardList()
        {
            _guardList = new GuardList();
        }

        public void InitializeStaffList()
        {
            _staffList = new StaffList();
        }

        public void SetupGame()
        {
            InitializePlayer();
            InitializeZoneMaster();
            InitializeGuardList();
            InitializeStaffList();
        }

        public void PlayGame()
        {
            ConsoleView viewWindow = new ConsoleView(_myPlayer, _staffList, _guardList, _zoneMaster);

            viewWindow.DisplayGreeting();
            bool validInput = false;
            bool playingGame = false;

            while (!validInput)
            {
                Commands command = viewWindow.GetPlayerCommand();

                if (command == Commands.play)
                {
                    playingGame = true;
                    validInput = true;
                }

                else if (command == Commands.quit)
                {
                    playingGame = false;
                    validInput = true;
                }
                else
                {
                    viewWindow.DisplayClear();
                    viewWindow.DisplayGreeting();
                }
            }

            bool initialPrompt = true;

            while (playingGame)
            {
                if (initialPrompt)
                {
                    viewWindow.DisplayInitialInformation();
                    initialPrompt = false;
                }

                Commands command = viewWindow.GetPlayerCommand();
                if (command == Commands.go)
                {
                    ZoneMaster.Directions direction = (ZoneMaster.Directions)Enum.Parse(typeof(ZoneMaster.Directions), viewWindow.GetPlayerSubject(command));
                    if (_zoneMaster.CheckValidMove(direction, _myPlayer.CurrentRoom[0], _myPlayer.CurrentRoom[1]))
                    {
                        int[] coords = _zoneMaster.MoveCoords(direction, _myPlayer.CurrentRoom[0], _myPlayer.CurrentRoom[1]);
                        _myPlayer.CurrentRoom = coords;

                        viewWindow.DisplayRoomInformation();
                    }
                    else
                    {
                        viewWindow.DisplayMessage("You cannot go that way!");
                    }
                }
                else if (command == Commands.look)
                {
                    viewWindow.DisplayMessage(viewWindow.GetPlayerSubject(command));
                }
                else if (command == Commands.wait)
                {
                    viewWindow.DisplayMessage("I'll wait here for a second");
                }
                else if(command == Commands.quit)
                {
                    playingGame = false;
                }
                else
                {
                    viewWindow.DisplayMessage("I cant do that right now.");
                }

            }


        }

        #endregion


        #region [ CONSTRUCTORS ]

        public GameController()
        {
            SetupGame();

            PlayGame();
        }

        #endregion
    }
}
