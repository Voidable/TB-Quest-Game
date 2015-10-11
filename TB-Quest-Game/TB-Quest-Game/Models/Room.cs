using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    class Room
    {
        #region [ FIELDS ]

        private string _name;
        private string _description;
        private int[] _coords;
        private bool _isLighted;
        private List<Guard> _guards;
        private List<Staff> _staff;
        private int[,] _doors;

        #endregion


        #region [ PROPERTIES ]

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Desciption
        {
            get { return _description; }
            set { _description = value; }
        }

        public int[] Coords
        {
            get { return _coords; }
            set { _coords = value; }
        }

        public bool IsLighed
        {
            get { return _isLighted; }
            set { _isLighted = value; }
        }

        public List<Guard> Guards
        {
            get { return _guards; }
            set { _guards = value; }
        }

        public List<Staff> Staff
        {
            get { return _staff; }
            set { _staff = value; }
        }

        public int[,] Doors
        {
            get { return _doors; }
            set { _doors = value; }
        }

        #endregion


        #region [ METHODS ]

        #endregion

        #region [ CONSTRUCTORS ]

        public Room()
        {
            _name = "Generic room";
            _description = "Blank white walls, ceiling and floor. Makes you feel uncomfortable";
            _coords = new int[2];
            {
                _coords[0] = 0; //  Floor number
                _coords[1] = 0; //  Room number
            }
            _isLighted = true;
            _guards = new List<Guard>();
            _staff = new List<Staff>();
            _doors = new int[10, 2];
            {   //  You cannot leave a generic room, MWAHAHAHA
                _doors[0, 0] = 0;   //  North
                _doors[0, 1] = 0;

                _doors[1, 0] = 0;   //  North-east
                _doors[1, 1] = 0;

                _doors[2, 0] = 0;   //  East
                _doors[2, 1] = 0;

                _doors[3, 0] = 0;   //  South-east
                _doors[3, 1] = 0;

                _doors[4, 0] = 0;   //  South
                _doors[4, 1] = 0;

                _doors[5, 0] = 0;   //  South-west
                _doors[5, 1] = 0;

                _doors[6, 0] = 0;   //  West    
                _doors[6, 1] = 0;

                _doors[7, 0] = 0;   //  NorthWest
                _doors[7, 1] = 0;

                _doors[8, 0] = 0;   //  Up  
                _doors[8, 1] = 0;

                _doors[9, 0] = 0;   //  Down
                _doors[9, 1] = 0;
            }
        }

        public Room(string name, int floorNumber, int roomNumber)
        {
            _name = name;
            _description = "Room cannot be described";
            _coords = new int[2];
            {
                _coords[0] = floorNumber; //  Floor number
                _coords[1] = roomNumber; //  Room number
            }
            _isLighted = true;
            _guards = new List<Guard>();
            _staff = new List<Staff>();
            _doors = new int[10, 2];
            {   //  Doors need to be set by the ZoneMaster
                _doors[0, 0] = 0;   //  North
                _doors[0, 1] = 0;

                _doors[1, 0] = 0;   //  North-east
                _doors[1, 1] = 0;

                _doors[2, 0] = 0;   //  East
                _doors[2, 1] = 0;

                _doors[3, 0] = 0;   //  South-east
                _doors[3, 1] = 0;

                _doors[4, 0] = 0;   //  South
                _doors[4, 1] = 0;

                _doors[5, 0] = 0;   //  South-west
                _doors[5, 1] = 0;

                _doors[6, 0] = 0;   //  West    
                _doors[6, 1] = 0;

                _doors[7, 0] = 0;   //  NorthWest
                _doors[7, 1] = 0;

                _doors[8, 0] = 0;   //  Up  
                _doors[8, 1] = 0;

                _doors[9, 0] = 0;   //  Down
                _doors[9, 1] = 0;
            }
        }

        #endregion









    }
}
