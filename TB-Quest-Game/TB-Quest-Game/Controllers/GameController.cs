using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest_Game
{
    public class GameController
    {
        private Player _myPlayer;

        public GameController()
        {
            SetupGame();

            PlayGame();
        }

        private void PlayGame()
        {
            
        }

        public void SetupGame()
        {
            InitializePlayer();
        }

        private void InitializePlayer()
        {

        }
    }
}
