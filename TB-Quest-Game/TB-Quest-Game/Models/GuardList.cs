using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class GuardList
    {
        #region [ FIELDS ]

        private List<Guard> _guards;

        #endregion


        #region [ PROPERTIES ]

        public List<Guard> Guards
        {
            get { return _guards; }
            set { _guards = value; }
        }

        #endregion

        #region [ METHODS ]

        public string GetGuardList()
        {
            string output = "";

            foreach (Guard g in Guards)
            {
                output = output + string.Format("{0}, a {1} {2}.", g.Name, g.Gender, g.Race);
            }

            return output;
        }

        public void InitializeGuards()
        {
            Guard doug = new Guard("Doug", Person.Genders.Male, Person.Races.Orc);
            int[] dougCoords = { 0, 0};
            doug.CurrentRoom = dougCoords;
            Guards.Add(doug);

            Guard sandra = new Guard("Sandra", Person.Genders.Female, Person.Races.Elf);
            int[] sandraCoords = { 0, 2 };
            sandra.CurrentRoom = sandraCoords;
            Guards.Add(sandra);

        }

        #endregion

        #region [ CONSTRUCTOR ]

        public GuardList()
        {
            _guards = new List<Guard>();
        }

        #endregion
    }
}
