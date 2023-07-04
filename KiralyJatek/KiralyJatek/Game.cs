using KiralyJatek.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiralyJatek
{
    internal class Game
    {
        private ASolver solver;

        public Game(ASolver solver)
        {
            this.solver = solver;
        }

        public void Play()
        {
            State currentState = new State();
            bool playersTurn = true;

            while (currentState.GetStatus() == '_')
            {
                Console.WriteLine(currentState);

                if (playersTurn)
                {
                    currentState = PlayersMove(currentState);
                }
                else
                {
                    currentState = AIsMove(currentState);
                }
                playersTurn = !playersTurn;
            }
            Console.WriteLine(currentState);
            Console.WriteLine("Winner: " + currentState.GetStatus());
        }


        private State PlayersMove(State currentState)
        {
            Operator op = null;
            int row = currentState.GetRow();
            int col = currentState.GetCol();
            while (op == null || !op.IsAplicable(currentState))
            {

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.KeyChar)
                {
                    case '1':
                        if (!currentState.IsOutOfBounds(row + 1, col - 1))
                        {
                            op = new Operator(row + 1, col - 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '2':
                        if (!currentState.IsOutOfBounds(row + 1, col))
                        {
                            op = new Operator(row + 1, col);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '3':
                        if (!currentState.IsOutOfBounds(row + 1, col + 1))
                        {
                            op = new Operator(row + 1, col + 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '4':
                        if (!currentState.IsOutOfBounds(row, col - 1))
                        {
                            op = new Operator(row, col - 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '6':
                        if (!currentState.IsOutOfBounds(row, col + 1))
                        {
                            op = new Operator(row, col + 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '7':
                        if (!currentState.IsOutOfBounds(row - 1, col - 1))
                        {
                            op = new Operator(row - 1, col - 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '8':
                        if (!currentState.IsOutOfBounds(row - 1, col))
                        { 
                            op = new Operator(row - 1, col);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    case '9':
                        if (!currentState.IsOutOfBounds(row - 1, col + 1))
                        {
                            op = new Operator(row - 1, col + 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Érvénytelen lépés");
                            break;
                        }
                    default:
                        break;
                }
            }

            return op.Apply(currentState);
        }


        private State AIsMove(State currentState)
        {
            State nextState = solver.NextMove(currentState);

            if (nextState == null)
            {
                throw new Exception("Cannot select next move.");
            }
            else
            {
                return nextState;
            }
        }
    }
}
