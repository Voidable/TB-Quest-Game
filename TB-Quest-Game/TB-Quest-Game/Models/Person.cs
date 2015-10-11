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

        public enum Races
        {
            Human,
            Elf,
            Dwarf,
            Orc
        }

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

        public string Name
        {
            get { return _name; }
        }

        public Races Race
        {
            get { return _race; }
        }

        public Genders Gender
        {
            get { return _gender; }
        }

        public int[] CurrentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        public bool Alive
        {
            get { return _isAlive; }
        }

        public string InitialGreeting
        {
            get { return _initialGreeting; }
            set { _initialGreeting = value; }
        }

        #endregion

        #region [ METHODS ]

        virtual public string Death()
        {
            this._isAlive = false;

            return string.Format("{0} has died.", this.Name);
        }

        #endregion

        #region [ CONSTRUCTOR ]

        public Person()
        {
            _name = "Mr. Smith";
            _gender = Genders.Male;
            _race = Races.Human;
            _currentRoom = new int[2];
            _isAlive = true;
        }

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
