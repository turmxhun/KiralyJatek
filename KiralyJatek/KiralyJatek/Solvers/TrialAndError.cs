﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiralyJatek.Solvers
{
    internal class TrialAndError : ASolver
    {
        private Random rnd = new Random();

        private Operator SelectOperators(State currentState)
        {
            List<int> indexList = new List<int>();
            while (indexList.Count < Operators.Count)
            {
                int index = rnd.Next(0, Operators.Count);
                while (indexList.Contains(index))
                {
                    index = rnd.Next(0, Operators.Count);
                }
                indexList.Add(index);
            }
            foreach (int i in indexList)
            {
                if (Operators[i].IsAplicable(currentState))
                {
                    return Operators[i];
                }
            }
            return null;
        }

        public override State NextMove(State currentState)
        {
            Operator op = SelectOperators(currentState);
            if (op == null)
            {
                return null;
            }
            return op.Apply(currentState);
        }
    }
}
