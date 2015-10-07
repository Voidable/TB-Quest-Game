using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class ConsoleView
    {
        private Player _myPlayer;

        public ConsoleView(Player myPlayer)
        {
            _myPlayer = myPlayer;
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine("Player name: {0}", _myPlayer.Name);
            Console.ReadKey();
        }
    }
}
