using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class StaffList
    {
        #region [ FIELDS ]

        private List<Staff> _staff;

        #endregion


        #region [ PROPERTIES ]

        public List<Staff> Staff
        {
            get { return _staff; }
            set { _staff = value; }
        }

        #endregion

        #region [ METHODS ]

        public string GetGuardList()
        {
            string output = "";

            foreach (Staff s in Staff)
            {
                output = output + string.Format("{0}, a {1} {2}.", s.Name, s.Gender, s.Race);
            }

            return output;
        }


        public void InitializeStaff()
        {
            Staff max = new Staff("Max", Person.Genders.Male, Person.Races.Human);
            int[] maxCoords = { 0, 0 };
            max.CurrentRoom = maxCoords;
            Staff.Add(max);

            Staff bertha = new Staff("Bertha", Person.Genders.Female, Person.Races.Dwarf);
            int[] berthaCoords = { 0, 3 };
            bertha.CurrentRoom = berthaCoords;
            Staff.Add(bertha);

        }

        #endregion

        #region [ CONSTRUCTOR ]

        public StaffList()
        {
            _staff = new List<Staff>();
        }

        #endregion
    }
}
