using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class GameController
    {

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
