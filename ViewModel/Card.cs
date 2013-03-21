using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriTowers.ViewModel
{
    public enum CardSuit
    {
        Spade,
        Heart,
        Diamond,
        Club,
        Joker
    }

    public class Card
    {
            public string Image { get; set; }
            public CardSuit Suit { get; set; }
            public int CardId { get; set; }
            public int Number { get; set; }
    }
}
