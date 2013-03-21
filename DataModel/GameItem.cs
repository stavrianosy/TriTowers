using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriTowers.DataModel
{
    public class GameItem:BaseItem
    {
        
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Stage { get; set; }

    }
}
