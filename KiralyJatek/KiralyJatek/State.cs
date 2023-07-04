using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiralyJatek
{
    internal class State : ICloneable
    {
        public char[,] Board = new char[6, 8]
        {
            {'_','_','_','_','_','_','_','_'},
            {'_','_','_','_','_','_','_','_'},
            {'w','_','_','_','_','_','_','_'},
            {'_','_','_','_','_','_','_','b'},
            {'_','_','_','_','_','_','_','_'},
            {'_','_','_','_','_','_','_','_'}
        };

        public char CurrentPlayer = 'w';

        public void ChangePlayer()
        {
            if (CurrentPlayer == 'w')
            {
                CurrentPlayer = 'b';
            }
            else
            {
                CurrentPlayer = 'w';
            }
        }
        public object Clone()
        {
            State newState = new State();
            newState.Board = (char[,])Board.Clone();
            newState.CurrentPlayer = CurrentPlayer;
            return newState;
        }
        public bool IsOutOfBounds(int row, int col)
        {
            return (row < 0 || row > 5 || col < 0 || col > 7);
        }

        public char GetStatus()
        {
            char winner = '_'; 
            int[] dx = { -1, -1, 0, 1, 1, 1, 0, -1 }; 
            int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == 'w' || Board[i, j] == 'b')
                    {
                        bool canMove = false;
                        for (int k = 0; k < 8; k++)
                        {
                            int ni = i + dx[k];
                            int nj = j + dy[k];
                            if (ni >= 0 && ni < 6 && nj >= 0 && nj < 8 && Board[ni, nj] == '_')
                            {
                                canMove = true;
                                break;
                            }
                        }
                        if (canMove)
                        {
                            winner = '_';
                            continue;
                        }
                        else
                        {
                            if (Board[i, j] == 'w')
                            {
                                winner = 'b';
                            }
                            else
                            {
                                winner = 'w';
                            }
                            return winner;
                        }
                    }
                }
            }
            return winner;
        }

        public int GetRow()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i,j] == 'w')
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public int GetCol()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == 'w')
                    {
                        return j;
                    }
                }
            }
            return -1;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Console.Clear();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sb.Append(Board[i, j] + "  ");
                }
                sb.AppendLine();
            }

            sb.AppendLine("\nCurrent player: " + CurrentPlayer);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            State other = obj as State;

            if (other.CurrentPlayer != CurrentPlayer)
            {
                return false;
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (other.Board[i, j] != Board[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
