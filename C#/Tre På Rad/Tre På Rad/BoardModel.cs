using System;
using System.Collections.Generic;
using System.Text;

namespace Tre_På_Rad
{
    class BoardModel
    {
        public CellModel[] Cells { get; }
        private readonly Random _random;

        public BoardModel()
        {
            Cells = new CellModel[9];
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = new CellModel();
            }
            _random = new Random();
        }

        public void AddDummyData()
        {
            Cells[0].Mark(true);
            Cells[1].Mark(false);
        }

        public void SetPlayer1(int index)
        {
            Cells[index].Mark(true);
        }

        public bool SetRandomPlayer2()
        {
            var availableIndexes = new List<int>();
            for (int i = 0; i < Cells.Length; i++)
            {
                if (Cells[i].IsEmpty()) availableIndexes.Add(i);
            }

            if (availableIndexes.Count == 0) return false;
            var randomAvailableIndex = _random.Next(0, availableIndexes.Count);
            var index = availableIndexes[randomAvailableIndex];
            Cells[index].Mark(false);
            return true;
        }

    }
}
