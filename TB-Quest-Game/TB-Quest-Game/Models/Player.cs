using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class Player : Person
    {

        private List<Item> _inventory;
        private string _initialGreeting;

        public string InitialGreeting
        {
            get { return _initialGreeting; }
            set { _initialGreeting = value; }
        }

        public string Decription()
        {
            //  Create holding strings
            string message = "";
            string friendlyPrefix = "un";

            //  String for the friendly prefix
            if (this.AppearsFriendly)
                friendlyPrefix = "";

            //  The player is very curt when on a job
            message = string.Format("{0} {1}, Name tag reads {2}. Looks {3}friendly.",
                this.Race,
                this.Gender,
                this.Name,
                friendlyPrefix);


            return message;
        }

        public Player(string name, Genders gender, Races race):base(name,gender,race)
        {
            _inventory = new List<Item>();
        }
    }
}
