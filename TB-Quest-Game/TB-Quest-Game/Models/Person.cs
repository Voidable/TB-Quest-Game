using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game.Models
{
    class Person
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
        private bool _appearsFriendly;
        private int[] _currentRoom;

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

        public bool AppearsFriendly
        {
            get { return _appearsFriendly; }
            set { _appearsFriendly = value; }
        }

        public int[] CurrentRoom
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        #endregion

        #region [ CONSTRUCTOR ]

        public Person()
        {
            _name = "Mr. Smith";
            _gender = Genders.Male;
            _race = Races.Human;
            _appearsFriendly = true;
        }

        public Person(string name,Genders gender, Races race)
        {
            _name = name;
            _gender = gender;
            _race = race;
            _appearsFriendly = true;
        }

        public Person(string name, Genders gender, Races race, bool looksFriendly)
        {
            _name = name;
            _gender = gender;
            _race = race;
            _appearsFriendly = looksFriendly;
        }

        #endregion
    }
}
