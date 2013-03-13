using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TriTowers.Pages
{
    enum CardSuit 
    {
        Spade,
        Heart,
        Diamond,
        Club,
        Joker
    }

    class CardIdentifier
    {
        public Card Card { get; set; }
        public int Level { get; set; }
        public int Position { get; set; }
        public int CardIdentifierId { get; set; }
    }
    class Card
    {
        public string Image { get; set; }
        public CardSuit  Suit { get; set; }
        public int CardId { get; set; }
        public int Number { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Deck : Page
    {
        Card cardOnHand;

        List<List<Card>> tower1;
        List<List<Card>> tower2;
        List<List<Card>> tower3;

        List<Card> deck;

        public Deck()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InitCards();
            ShuffleDeck();
        }

        void InitCards()
        {
            Card card1 = new Card() { Suit = CardSuit.Spade, Number = 1 };
            Card card2 = new Card() { Suit = CardSuit.Spade, Number = 2 };
            Card card3 = new Card() { Suit = CardSuit.Spade, Number = 3 };
            Card card4 = new Card() { Suit = CardSuit.Spade, Number = 4 };
            Card card5 = new Card() { Suit = CardSuit.Spade, Number = 5 };
            Card card6 = new Card() { Suit = CardSuit.Spade, Number = 6 };
            Card card7 = new Card() { Suit = CardSuit.Spade, Number = 7 };
            Card card8 = new Card() { Suit = CardSuit.Spade, Number = 8 };
            Card card9 = new Card() { Suit = CardSuit.Spade, Number = 9 };
            Card card10 = new Card() { Suit = CardSuit.Spade, Number = 10 };
            Card card11 = new Card() { Suit = CardSuit.Spade, Number = 11 };
            Card card12 = new Card() { Suit = CardSuit.Spade, Number = 12 };
            Card card13 = new Card() { Suit = CardSuit.Spade, Number = 13 };

            Card card14 = new Card() { Suit = CardSuit.Heart, Number = 1 };
            Card card15 = new Card() { Suit = CardSuit.Heart, Number = 2 };
            Card card16 = new Card() { Suit = CardSuit.Heart, Number = 3 };
            Card card17 = new Card() { Suit = CardSuit.Heart, Number = 4 };
            Card card18 = new Card() { Suit = CardSuit.Heart, Number = 5 };
            Card card19 = new Card() { Suit = CardSuit.Heart, Number = 6 };
            Card card20 = new Card() { Suit = CardSuit.Heart, Number = 7 };
            Card card21 = new Card() { Suit = CardSuit.Heart, Number = 8 };
            Card card22 = new Card() { Suit = CardSuit.Heart, Number = 9 };
            Card card23 = new Card() { Suit = CardSuit.Heart, Number = 10 };
            Card card24 = new Card() { Suit = CardSuit.Heart, Number = 11 };
            Card card25 = new Card() { Suit = CardSuit.Heart, Number = 12 };
            Card card26 = new Card() { Suit = CardSuit.Heart, Number = 13 };

            Card card27 = new Card() { Suit = CardSuit.Diamond, Number = 1 };
            Card card28 = new Card() { Suit = CardSuit.Diamond, Number = 2 };
            Card card29 = new Card() { Suit = CardSuit.Diamond, Number = 3 };
            Card card30 = new Card() { Suit = CardSuit.Diamond, Number = 4 };
            Card card31 = new Card() { Suit = CardSuit.Diamond, Number = 5 };
            Card card32 = new Card() { Suit = CardSuit.Diamond, Number = 6 };
            Card card33 = new Card() { Suit = CardSuit.Diamond, Number = 7 };
            Card card34 = new Card() { Suit = CardSuit.Diamond, Number = 8 };
            Card card35 = new Card() { Suit = CardSuit.Diamond, Number = 9 };
            Card card36 = new Card() { Suit = CardSuit.Diamond, Number = 10 };
            Card card37 = new Card() { Suit = CardSuit.Diamond, Number = 11 };
            Card card38 = new Card() { Suit = CardSuit.Diamond, Number = 12 };
            Card card39 = new Card() { Suit = CardSuit.Diamond, Number = 13 };

            Card card40 = new Card() { Suit = CardSuit.Club, Number = 1 };
            Card card41 = new Card() { Suit = CardSuit.Club, Number = 2 };
            Card card42 = new Card() { Suit = CardSuit.Club, Number = 3 };
            Card card43 = new Card() { Suit = CardSuit.Club, Number = 4 };
            Card card44 = new Card() { Suit = CardSuit.Club, Number = 5 };
            Card card45 = new Card() { Suit = CardSuit.Club, Number = 6 };
            Card card46 = new Card() { Suit = CardSuit.Club, Number = 7 };
            Card card47 = new Card() { Suit = CardSuit.Club, Number = 8 };
            Card card48 = new Card() { Suit = CardSuit.Club, Number = 9 };
            Card card49 = new Card() { Suit = CardSuit.Club, Number = 10 };
            Card card50 = new Card() { Suit = CardSuit.Club, Number = 11 };
            Card card51 = new Card() { Suit = CardSuit.Club, Number = 12 };
            Card card52 = new Card() { Suit = CardSuit.Club, Number = 13 };

            Card card53 = new Card() { Suit = CardSuit.Joker, Number = 0 };
            Card card54 = new Card() { Suit = CardSuit.Joker, Number = 0 };


            List<Card> level1_1 = new List<Card>() { card1 };
            List<Card> level1_2 = new List<Card>() { card2, card3 };
            List<Card> level1_3 = new List<Card>() { card4, card5, card6 };
            List<Card> level1_4 = new List<Card>() { card7, card8, card9, card10 };
            List<Card> level1_5 = new List<Card>() { card11, card12, card13, card14, card15 };

            List<Card> level2_1 = new List<Card>() { card16 };
            List<Card> level2_2 = new List<Card>() { card17, card18 };
            List<Card> level2_3 = new List<Card>() { card19, card20, card21 };
            List<Card> level2_4 = new List<Card>() { card22, card23, card24, card25 };
            List<Card> level2_5 = new List<Card>() { card26, card27, card28, card29, card30 };

            List<Card> level3_1 = new List<Card>() { card31 };
            List<Card> level3_2 = new List<Card>() { card32, card33 };
            List<Card> level3_3 = new List<Card>() { card34, card35, card36 };
            List<Card> level3_4 = new List<Card>() { card37, card38, card39, card40 };
            List<Card> level3_5 = new List<Card>() { card41, card42, card43, card44, card45 };

            //ListOfLevels
            tower1 = new List<List<Card>>() { level1_1, level1_2, level1_3, level1_4, level1_5 };
            tower2 = new List<List<Card>>() { level2_1, level2_2, level2_3, level2_4, level2_5 };
            tower3 = new List<List<Card>>() { level3_1, level3_2, level3_3, level3_4, level3_5 };

            deck = new List<Card>() { card46, card47, card48, card49, card50, card51, card52, card53 };

            cardOnHand = card54;
            (rectCardOnHand.Child as TextBlock).Text = cardOnHand.Number.ToString();
        }

        void ShuffleDeck()
        {
            SetupTower(cnvFirst, tower1);
            SetupTower(cnvSecond, tower2);
            SetupTower(cnvThird, tower3);

            SetupDeck(cnvDeck, deck);
        }
        
        private void SetupDeck(Canvas canvas, List<Card> deck)
        {
            var index = 0;
            //Setup deck
                foreach (var card in deck)
                {
                    var crd = new CardIdentifier() { CardIdentifierId = index, Level = 0, Card = card, Position = index };
                    (canvas.Children[index] as Border).Tag = crd;
                    (canvas.Children[index] as Border).Margin = new Thickness(0);
                    //((canvas.Children[index] as Border).Child as TextBlock).Text = crd.Card.Number.ToString();
                    index++;
                }
        }

        void SetupTower(Canvas canvas, List<List<Card>> tower)
        {
            var index = 0;
            var levelIndex = 0;
            //Setup towers
            foreach (var level in tower)
            {
                var position = 0;
                foreach (var card in level)
                {
                    var crd = new CardIdentifier() { CardIdentifierId = index, Level = levelIndex, Card = card, Position = position };
                    (canvas.Children[index] as Border).Tag = crd;
                    (canvas.Children[index] as Border).Margin = new Thickness(0);
                    if(tower.Count > crd.Level+1)
                        (canvas.Children[index] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 0, G = 140, B = 140, A = 255 });

                    ((canvas.Children[index] as Border).Child as TextBlock).Text = crd.Card.Number.ToString();
                    index++;
                    position++;
                }
                levelIndex++;
            }

            //Card on hand
            //rectCardOnHand.Tag = cardOnHand;
        }

        private void cardTower1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog dialog = null;

            var card = (sender as Border);
            var selectedCard = card.Tag as CardIdentifier;
            var b = RemoveCard(tower1, selectedCard);
            if (b)
            {
                card.Margin = new Thickness(0, -1000, 0, 0);
                cardOnHand = selectedCard.Card;

                var before = selectedCard.Position > 0 && tower1[selectedCard.Level][selectedCard.Position-1] == null;
                var after = selectedCard.Position < tower1[selectedCard.Level].Count - 1 && tower1[selectedCard.Level][selectedCard.Position + 1] == null;
               
                if (before)
                    (cnvFirst.Children[GetChildIndex(selectedCard)] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A=255 });
                if (after)
                    (cnvFirst.Children[GetChildIndex(selectedCard) + 1] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A=255 });
                
                    tower1[selectedCard.Level][selectedCard.Position] = null;
                    (rectCardOnHand.Child as TextBlock).Text = selectedCard.Card.Number.ToString();
            }

        }

        private void cardTower2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var card = (sender as Border);
            var selectedCard = card.Tag as CardIdentifier;
            var b = RemoveCard(tower2 , selectedCard);
            if (b)
            {
                card.Margin = new Thickness(0, -1000, 0, 0);
                cardOnHand = selectedCard.Card;
                
                var before = selectedCard.Position > 0 && tower2[selectedCard.Level][selectedCard.Position - 1] == null;
                var after = selectedCard.Position < tower2[selectedCard.Level].Count - 1 && tower2[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                    (cnvSecond.Children[GetChildIndex(selectedCard)] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                if (after)
                    (cnvSecond.Children[GetChildIndex(selectedCard) + 1] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });

                tower2[selectedCard.Level][selectedCard.Position] = null;
                (rectCardOnHand.Child as TextBlock).Text = selectedCard.Card.Number.ToString();
            }

        }

        private void cardTower3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var card = (sender as Border);
            var selectedCard = card.Tag as CardIdentifier;
            var b = RemoveCard(tower3, selectedCard);
            if (b)
            {
                card.Margin = new Thickness(0, -1000, 0, 0);
                cardOnHand = selectedCard.Card;

                var before = selectedCard.Position > 0 && tower3[selectedCard.Level][selectedCard.Position - 1] == null;
                var after = selectedCard.Position < tower3[selectedCard.Level].Count - 1 && tower3[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                    (cnvThird.Children[GetChildIndex(selectedCard)] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                if (after)
                    (cnvThird.Children[GetChildIndex(selectedCard) + 1] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });

                tower3[selectedCard.Level][selectedCard.Position] = null;
                (rectCardOnHand.Child as TextBlock).Text = selectedCard.Card.Number.ToString();

            }

        }

        bool RemoveCard(List<List<Card>> tower, CardIdentifier selectedCard)
        {
            //apply the rules to remove a card
            var rule1 = cardOnHand.Number == 0 || selectedCard.Card.Number ==0 || 
                cardOnHand.Number == selectedCard.Card.Number + 1 || cardOnHand.Number == selectedCard.Card.Number - 1;
            var rule2 = tower.Count == selectedCard.Level+1 || 
                (tower[selectedCard.Level + 1][selectedCard.Position] == null && tower[selectedCard.Level + 1][selectedCard.Position + 1] == null);
            

            return rule1 && rule2;
        }

        int GetChildIndex(CardIdentifier selectedCard)
        {
            int result = 0;
            for (int i=0; i < selectedCard.Level; i++)
                result += i;

            result += selectedCard.Position-1;

            return result;
        }

        private void cardDeck_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var card = (sender as Border);
            var selectedCard = card.Tag as CardIdentifier;

            card.Margin = new Thickness(0, -1000, 0, 0);
            cardOnHand = selectedCard.Card;

            (rectCardOnHand.Child as TextBlock).Text = cardOnHand.Number.ToString();

        }

        private void txtRestart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InitCards();
            ShuffleDeck();
        }

    }
}
