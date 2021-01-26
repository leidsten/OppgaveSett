using System;
using System.Collections.Generic;
using System.Text;

namespace Tre_På_Rad
{
    class BoardView
    {
        public static void Show(BoardModel m)
        {
            Console.Clear();
            Console.WriteLine(
                "  a b c\n" +
                " ┌─────┐\n" +
                "1│" + GetChar(m, 0) + " " + GetChar(m, 1) + " " + GetChar(m, 2) + "│\n" +
                "2│" + GetChar(m, 3) + " " + GetChar(m, 4) + " " + GetChar(m, 5) + "│\n" +
                "3│" + GetChar(m, 6) + " " + GetChar(m, 7) + " " + GetChar(m, 8) + "│\n" +
                " └─────┘");
        }

        private static char GetChar(BoardModel boardModel, int index)
        {
            var cell = boardModel.Cells[index];
            if (cell.IsEmpty()) return ' ';
            return cell.IsPlayer1() ? 'x' : 'o';
        }
    }
}
