using KiralyJatek.Solvers;
using System;

namespace KiralyJatek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new TrialAndError());
            game.Play();
            Console.ReadLine();
        }
    }
}
