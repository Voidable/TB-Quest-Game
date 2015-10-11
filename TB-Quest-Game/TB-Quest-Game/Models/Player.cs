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

        public Player(string name, Genders gender, Races race):base(name,gender,race)
        {
            _inventory = new List<Item>();
        }

        override public string Death()
        {
            this._isAlive = false;

            return string.Format("I hav died.", this.Name);
        }
    }
}
