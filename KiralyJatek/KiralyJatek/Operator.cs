using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiralyJatek
{
    internal class Operator
    {
        public int Row;
        public int Col;
        public Operator(int row, int col) 
        {
            Row = row;
            Col = col;
        }

        public bool IsAplicable(State state)
        {
            int[] dx = { -1, -1, 0, 1, 1, 1, 0, -1 }; 
            int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };
            bool isPlayer = false;
            if (state.Board[Row,Col] != '_')
            {
                return false;
            }
            for (int k = 0; k < 8; k++)
            { 
                int ni = Row + dx[k];
                int nj = Col + dy[k];

                if (ni >= 0 && ni < 6 && nj >= 0 && nj < 8)
                {
                    if (state.Board[ni,nj] == state.CurrentPlayer)
                    {
                        state.Board[ni, nj] = 'x';
                        isPlayer = true;
                    }
                }
            }
            return isPlayer;

        }

        public State Apply(State state)
        {
            State newState = (State)state.Clone();
            newState.Board[Row, Col] = state.CurrentPlayer;
            newState.ChangePlayer();
            return newState;
        }
    }
}
