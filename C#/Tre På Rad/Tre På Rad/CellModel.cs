using System;
using System.Collections.Generic;
using System.Text;

namespace Tre_På_Rad
{

    public class CellModel
    {
        /* Vi har bestemt
         * 0 betyr tom
         * 1 betyr player 1
         * 2 betyr player 2
         */
        private int _content;

        public CellModel()
        {
            _content = 0;
        }

        public bool IsEmpty()
        {
            return _content == 0;
        }

        public bool IsPlayer1()
        {
            return _content == 1;
        }

        public void Mark(bool isPlayer1)
        {
            if (!IsEmpty()) return;
            _content = isPlayer1 ? 1 : 2;
        }
    }
}
