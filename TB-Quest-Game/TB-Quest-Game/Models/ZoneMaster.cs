using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    class ZoneMaster
    {
        #region [ FIELDS ]

        private Room[,] _rooms;

        #endregion


        #region [ PROPERTIES ]

        public Room[,] Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }

        #endregion


        #region [ METHODS]

        public void InitializeRooms()
        {
            _rooms[0, 0] = new Room("North of building", 0, 0);
            _rooms[0, 0].Desciption = "You are north of the building, there is a street to the west and an alley to the east";
            #region Doors 
            _rooms[0, 0].Doors[0, 1] = 0;   //  NORTH - Not possible

            _rooms[0, 0].Doors[1, 1] = 0;   //  NORTH-EAST - Not possible

            _rooms[0, 0].Doors[2, 1] = 1;   //  EAST - To alley

            _rooms[0, 0].Doors[3, 1] = 1;   //  SOUTH-EAST - To alley

            _rooms[0, 0].Doors[4, 1] = 0;   //  SOUTH - To inside of building, TODO

            _rooms[0, 0].Doors[5, 1] = 3;   //  SOUTH-WEST - To street

            _rooms[0, 0].Doors[6, 1] = 3;   //  WEST - To street

            _rooms[0, 0].Doors[7, 1] = 0;   //  NORTH-WEST - Not possible

            _rooms[0, 0].Doors[8, 0] = 0;   //  UP
            _rooms[0, 0].Doors[8, 1] = 0;   //  Not possible

            _rooms[0, 0].Doors[9, 0] = 0;   //  DOWN
            _rooms[0, 0].Doors[9, 1] = 0;   //  Not Possible
            #endregion

            _rooms[0, 1] = new Room("Alley", 0, 1);
            _rooms[0, 1].Desciption = "You are in an alley east of the building, the alley runs north - south";
            #region Doors 
            _rooms[0, 1].Doors[0, 1] = 0;   //  NORTH - North of building

            _rooms[0, 1].Doors[1, 1] = 1;   //  NORTH-EAST - Not possible

            _rooms[0, 1].Doors[2, 1] = 1;   //  EAST - Not possible

            _rooms[0, 1].Doors[3, 1] = 1;   //  SOUTH-EAST - Not possible

            _rooms[0, 1].Doors[4, 1] = 2;   //  SOUTH - South of building

            _rooms[0, 1].Doors[5, 1] = 2;   //  SOUTH-WEST - South of building

            _rooms[0, 1].Doors[6, 1] = 1;   //  WEST - Not possible

            _rooms[0, 1].Doors[7, 1] = 0;   //  NORTH-WEST - North of building

            _rooms[0, 1].Doors[8, 0] = 0;   //  UP
            _rooms[0, 1].Doors[8, 1] = 1;   //  Not possible

            _rooms[0, 1].Doors[9, 0] = 0;   //  DOWN
            _rooms[0, 1].Doors[9, 1] = 1;   //  Not Possible
            #endregion

            _rooms[0, 2] = new Room("South of building", 0, 2);
            _rooms[0, 2].Desciption = "You are south of the building, there is a street to the west and an alley to the east";
            #region Doors 
            _rooms[0, 2].Doors[0, 1] = 2;   //  NORTH - Enter building TODO

            _rooms[0, 2].Doors[1, 1] = 1;   //  NORTH-EAST - Alley

            _rooms[0, 2].Doors[2, 1] = 1;   //  EAST - Alley

            _rooms[0, 2].Doors[3, 1] = 2;   //  SOUTH-EAST - Not possible

            _rooms[0, 2].Doors[4, 1] = 2;   //  SOUTH - Not possible

            _rooms[0, 2].Doors[5, 1] = 2;   //  SOUTH-WEST - Not possible

            _rooms[0, 2].Doors[6, 1] = 3;   //  WEST - Street

            _rooms[0, 2].Doors[7, 1] = 3;   //  NORTH-WEST - Street

            _rooms[0, 2].Doors[8, 0] = 0;   //  UP
            _rooms[0, 2].Doors[8, 1] = 2;   //  Not possible

            _rooms[0, 2].Doors[9, 0] = 0;   //  DOWN
            _rooms[0, 2].Doors[9, 1] = 2;   //  Not Possible
            #endregion

            _rooms[0, 3] = new Room("Street", 0, 3);
            _rooms[0, 3].Desciption = "You are on the street west of the building, it runs north - south";
            #region Doors 
            _rooms[0, 3].Doors[0, 1] = 0;   //  NORTH - North of building

            _rooms[0, 3].Doors[1, 1] = 0;   //  NORTH-EAST - North of building

            _rooms[0, 3].Doors[2, 1] = 3;   //  EAST - Not possible

            _rooms[0, 3].Doors[3, 1] = 2;   //  SOUTH-EAST - South of building

            _rooms[0, 3].Doors[4, 1] = 2;   //  SOUTH - South of building

            _rooms[0, 3].Doors[5, 1] = 3;   //  SOUTH-WEST - Not possible

            _rooms[0, 3].Doors[6, 1] = 3;   //  WEST - Not possible

            _rooms[0, 3].Doors[7, 1] = 3;   //  NORTH-WEST - Not possible

            _rooms[0, 3].Doors[8, 0] = 0;   //  UP
            _rooms[0, 3].Doors[8, 1] = 3;   //  Not possible

            _rooms[0, 3].Doors[9, 0] = 0;   //  DOWN
            _rooms[0, 3].Doors[9, 1] = 3;   //  Not Possible
            #endregion
        }

        #endregion


        #region [ CONSTUCTORS ]

        public ZoneMaster()
        {
            _rooms = new Room[6, 10];
        }

        #endregion

    }
}
