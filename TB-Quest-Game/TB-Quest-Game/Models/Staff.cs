using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class Staff : Person
    {
        #region [ FIELDS ]

        private List<Item> _inventory;
        private bool _appearsFriendly;

        #endregion


        #region [ PROPERTIES ]

        public bool AppearsFriendly
        {
            get { return _appearsFriendly; }
            set { _appearsFriendly = value; }
        }

        #endregion

        #region [ METHODS ]

        /// <summary>
        /// Returns a string of the player describing the person
        /// </summary>
        /// <returns></returns>
        public string Decription()
        {
            //  Create holding strings
            string message = "";
            string friendlyPrefix = "un";
            string genderReference = "his";

            //  String for the friendly prefix
            if (this.AppearsFriendly)
                friendlyPrefix = "";

            //string for the gender reference
            if (this.Gender == Genders.Female)
                genderReference = "her";


            if (Alive)  // Staff is alive
            {
                //  The player is describing 
                message = string.Format("An {3}friendly looking {0} staff member, according to {1} nametag {1} name is {2}",
                    this.Race,
                    genderReference,
                    this.Name,
                    friendlyPrefix);
            }
            else   //   Staff is dead
            {
                //  The player doesn't have much to say about dead people
                message = string.Format("A dead {0} is laying on the ground, {1} nametag says {2}",
                    this.Race,
                    genderReference,
                    this.Name);
            }

            return message;
        }

        /// <summary>
        /// Returns the staff's death method
        /// </summary>
        /// <returns></returns>
        override public string Death()
        {
            this._isAlive = false;

            return string.Format("The staff-member {0} has died.", this.Name);
        }

        #endregion


        #region [ CONSTRUCTOR ]

        /// <summary>
        /// Constructor for Staff, assumes friendly and tells people their name
        /// </summary>
        /// <param name="name">Staffs name</param>
        /// <param name="gender">Staff gender</param>
        /// <param name="race">Staffs race</param>
        public Staff(string name, Genders gender, Races race) : base(name, gender, race)
        {
            AppearsFriendly = true;
            InitialGreeting = string.Format("Why hello there, my name is {0}", this.Name);
            _inventory = new List<Item>();
        }

        #endregion
    }
}
