using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Model
    {
        
        public Viewmodel viewmodel;
        bool player1 = true;
        bool player2 = false;
        int[,] matrix =
        {
               { 0,0,0,},
               { 0,0,0,},
               { 0,0,0,},
        };


        public void main(int x, int y)
        {          
            if (IsGameEnd() || matrix[x, y] != 0)
                return;

            int newvalue = WhoGo();
            ChangePlayer();
            matrix[x, y] = newvalue;
            viewmodel.ChangeValue(x, y, newvalue);

        }
        int WhoGo()
        {
            if (player1)
                return 1;
            if (player2)
                return 2;
            throw new Exception("неизвестный ход");
        }
        void ChangePlayer()
        {
            player1 = !player1;
            player2 = !player2;
           
        }
        public bool IsGameEnd()
        {
            for (int i = 0; i < 3; ++i)
            {
                if ((matrix[i, 0] == matrix[i, 1] && matrix[i, 1] == matrix[i, 2] && matrix[i, 0] != 0) ||
                    matrix[0, i] == matrix[1, i] && matrix[1, i] == matrix[2, i] && matrix[0, i] != 0)
                {
                    return true;
                }
            }

            if ((matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2] && matrix[0, 0] != 0) ||
                (matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0] && matrix[0, 2] != 0))
            {
                return true;
            }

            return false;
        }


    }


        
}   
