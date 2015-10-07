using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    class Guard : Person
    {
        #region [ FIELDS ]

        private List<Item> _inventory;
        private bool _appearsFriendly;
        private string _initialGreeting;
        private bool _isAlive;

        #endregion


        #region [ PROPERTIES ]

        public string InitialGreeting
        {
            get { return _initialGreeting; }
            set { _initialGreeting = value; }
        }

        public bool AppearsFriendly
        {
            get { return _appearsFriendly; }
            set { _appearsFriendly = value; }
        }

        public bool Alive
        {
            get { return _isAlive; }
            set { _isAlive = value}
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

            //  String for the friendly prefix
            if (this.AppearsFriendly)
                friendlyPrefix = "";
            
            if (Alive)  // Guard is alive
            {
                //  The player is very curt when describing living people
                message = string.Format("{0} {1}, Nametag reads {2}. Looks {3}friendly.",
                    this.Race,
                    this.Gender,
                    this.Name,
                    friendlyPrefix);
            }
            else   //   Guard is dead
            {
                //  The player has more time to describe dead people
                message = string.Format("The {0} {1} is laying dead on the ground, according to their nametag their name is {2}",
                    this.Gender,
                    this.Race,
                    this.Name);
            }

            return message;
        }

        #endregion


        #region [ CONSTRUCTOR

        /// <summary>
        /// Constructor for Guards, assumes unfriendly and tells people to move along
        /// </summary>
        /// <param name="name">Guards name</param>
        /// <param name="gender">Guards gender</param>
        /// <param name="race">Guards race</param>
        public Guard(string name, Genders gender, Races race) : base(name, gender, race)
        {
            AppearsFriendly = false;
            InitialGreeting = "You should not be here!";
            _inventory = new List<Item>();
        }

        #endregion
    }
}
