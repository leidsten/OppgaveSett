using System;
using System.Threading;

namespace Tre_På_Rad
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardModel = new BoardModel();
            while (true)
            {
                BoardView.Show(boardModel);
                Console.Write("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
                var position = Console.ReadLine();
                var col = position[0] - 'a';
                var row = position[1] - '1';
                var index = row * 3 + col;
                boardModel.SetPlayer1(index);
                BoardView.Show(boardModel);
                Thread.Sleep(700);
                var success = boardModel.SetRandomPlayer2();
                if (!success) return;
            }
        }
    }
}
