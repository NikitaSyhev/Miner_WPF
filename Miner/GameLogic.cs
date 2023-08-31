using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Miner
{
    internal class GameLogic
    {

        private bool IsMine = false;
        private void gameLost()
        {
            this.IsMine = true;
            MessageBox.Show("You Lost");
        }

        private void gameWin()
        {
           
            
        }
    }





    }

