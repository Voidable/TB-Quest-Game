using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class Person
    {
        #region [ ENUMERATION ]

        /// <summary>
        /// Enumeration of possible races
        /// </summary>
        public enum Races
        {
            Human,
            Elf,
            Dwarf,
            Orc
        }

        /// <summary>
        /// Enumeration of genders
        /// </summary>
        public enum Genders
        {
            Male,
            Female
        }

        #endregion

        #region [ FIELDS ]

        private string _name;
        private Races _race;
        private Genders _gender;
        private int[] _currentRoom;
        protected bool _isAlive;
        private string _initialGreeting;

        #endregion

        #region [ PROPERTIES ]

        /// <summary>
        /// Person's name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Person's race
        /// </summary>
        public Races Race
        {
            get { return _race; }
        }

        /// <summary>
        /// Person's gender
        /// </summary>
        public Genders Gender
        {
            get { return _gender; }
        }

        /// <summary>
        /// Person's current location
        /// </summary>
        public int[] CurrentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        /// <summary>
        /// Is the person alive
        /// </summary>
        public bool Alive
        {
            get { return _isAlive; }
        }

        /// <summary>
        /// The person's initial greeting when you talk to them
        /// </summary>
        public string InitialGreeting
        {
            get { return _initialGreeting; }
            set { _initialGreeting = value; }
        }

        #endregion

        #region [ METHODS ]

        /// <summary>
        /// Person is now kill
        /// </summary>
        /// <returns>Death message</returns>
        virtual public string Death()
        {
            this._isAlive = false;

            return string.Format("{0} has died.", this.Name);
        }

        #endregion

        #region [ CONSTRUCTOR ]

        /// <summary>
        /// Default person constructor
        /// </summary>
        public Person()
        {
            _name = "Mr. Smith";
            _gender = Genders.Male;
            _race = Races.Human;
            _currentRoom = new int[2];
            _isAlive = true;
        }

        /// <summary>
        /// Overloaded person constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="race"></param>
        public Person(string name,Genders gender, Races race)
        {
            _name = name;
            _gender = gender;
            _race = race;
            _currentRoom = new int[2];
            _isAlive = true;
        }

        #endregion
    }
}
