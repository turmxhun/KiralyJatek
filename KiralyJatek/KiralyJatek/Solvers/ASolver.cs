using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiralyJatek.Solvers
{
    internal abstract class ASolver
    {
        public List<Operator> Operators = new List<Operator>();
        public ASolver()
        {
            GenerateOperators();
        }

        private void GenerateOperators()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Operators.Add(new Operator(i, j));
                }
            }
        }

        public abstract State NextMove(State currentState);
    }
}
