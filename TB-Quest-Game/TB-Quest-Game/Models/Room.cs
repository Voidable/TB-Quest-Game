using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class Room
    {
        #region [ FIELDS ]

        private string _name;
        private string _description;
        private int[] _coords;
        private bool _isLighted;
        private int[,] _doors;

        #endregion


        #region [ PROPERTIES ]

        /// <summary>
        /// Name of room
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Description of room
        /// </summary>
        public string Desciption
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Coordinates of the room
        /// </summary>
        public int[] Coords
        {
            get { return _coords; }
            set { _coords = value; }
        }

        /// <summary>
        /// Is the room bright enough to see
        /// </summary>
        public bool IsLighed
        {
            get { return _isLighted; }
            set { _isLighted = value; }
        }

        /// <summary>
        /// Array of movable directions
        /// </summary>
        public int[,] Doors
        {
            get { return _doors; }
            set { _doors = value; }
        }

        #endregion


        #region [ CONSTRUCTORS ]

        /// <summary>
        /// Default constructor, makes an inescapable room
        /// </summary>
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

        /// <summary>
        /// Overloaded room constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="floorNumber"></param>
        /// <param name="roomNumber"></param>
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
