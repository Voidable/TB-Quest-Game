using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class Player : Person
    {
        #region [ FIELDS ]

        // Player's inventory
        private List<Item> _inventory;

        #endregion

        #region [ PROPERTIES ]

        //  Player's inventory
        public List<Item> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region [ METHODS ]

        /// <summary>
        /// Player has lost the game
        /// </summary>
        /// <returns></returns>
        override public string Death()
        {
            this._isAlive = false;

            return string.Format("I have died.", this.Name);
        }

        #endregion


        #region [ CONSTRUCTORS ]

        /// <summary>
        /// Overloaded Player Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="race"></param>
        public Player(string name, Genders gender, Races race) : base(name, gender, race)
        {
            _inventory = new List<Item>();
        }

        #endregion


    }
}
