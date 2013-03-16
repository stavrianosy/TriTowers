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
using Windows.UI.Xaml.Media.Imaging;
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

        int Countdown { get; set; }
        int Points { get; set; }
        int Stage { get; set; }

        DispatcherTimer dispatcherTimer;

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
            Reset();
            InitCards();
            ShuffleDeck();
        }

        void InitCards()
        {
            Card card1 = new Card() { Image="1c", Suit =  CardSuit.Spade, Number = 1 };
            Card card2 = new Card() { Image="2c", Suit =  CardSuit.Spade, Number = 2 };
            Card card3 = new Card() { Image="3c", Suit =  CardSuit.Spade, Number = 3 };
            Card card4 = new Card() { Image="4c", Suit =  CardSuit.Spade, Number = 4 };
            Card card5 = new Card() { Image="5c", Suit =  CardSuit.Spade, Number = 5 };
            Card card6 = new Card() { Image="6c", Suit =  CardSuit.Spade, Number = 6 };
            Card card7 = new Card() { Image="7c", Suit =  CardSuit.Spade, Number = 7 };
            Card card8 = new Card() { Image="8c", Suit =  CardSuit.Spade, Number = 8 };
            Card card9 = new Card() { Image="9c", Suit =  CardSuit.Spade, Number = 9 };
            Card card10 = new Card() { Image="10c", Suit =  CardSuit.Spade, Number = 10 };
            Card card11 = new Card() { Image="11c", Suit =  CardSuit.Spade, Number = 11 };
            Card card12 = new Card() { Image="12c", Suit =  CardSuit.Spade, Number = 12 };
            Card card13 = new Card() { Image="13c", Suit =  CardSuit.Spade, Number = 13 };

            Card card14 = new Card() { Image="1d", Suit =  CardSuit.Heart, Number = 1 };
            Card card15 = new Card() { Image="2d", Suit =  CardSuit.Heart, Number = 2 };
            Card card16 = new Card() { Image="3d", Suit =  CardSuit.Heart, Number = 3 };
            Card card17 = new Card() { Image="4d", Suit =  CardSuit.Heart, Number = 4 };
            Card card18 = new Card() { Image="5d", Suit =  CardSuit.Heart, Number = 5 };
            Card card19 = new Card() { Image="6d", Suit =  CardSuit.Heart, Number = 6 };
            Card card20 = new Card() { Image="7d", Suit =  CardSuit.Heart, Number = 7 };
            Card card21 = new Card() { Image="8d", Suit =  CardSuit.Heart, Number = 8 };
            Card card22 = new Card() { Image="9d", Suit =  CardSuit.Heart, Number = 9 };
            Card card23 = new Card() { Image="10d", Suit =  CardSuit.Heart, Number = 10 };
            Card card24 = new Card() { Image="11d", Suit =  CardSuit.Heart, Number = 11 };
            Card card25 = new Card() { Image="12d", Suit =  CardSuit.Heart, Number = 12 };
            Card card26 = new Card() { Image="13d", Suit =  CardSuit.Heart, Number = 13 };

            Card card27 = new Card() { Image="1h", Suit =  CardSuit.Diamond, Number = 1 };
            Card card28 = new Card() { Image="2h", Suit =  CardSuit.Diamond, Number = 2 };
            Card card29 = new Card() { Image="3h", Suit =  CardSuit.Diamond, Number = 3 };
            Card card30 = new Card() { Image="4h", Suit =  CardSuit.Diamond, Number = 4 };
            Card card31 = new Card() { Image="5h", Suit =  CardSuit.Diamond, Number = 5 };
            Card card32 = new Card() { Image="6h", Suit =  CardSuit.Diamond, Number = 6 };
            Card card33 = new Card() { Image="7h", Suit =  CardSuit.Diamond, Number = 7 };
            Card card34 = new Card() { Image="8h", Suit =  CardSuit.Diamond, Number = 8 };
            Card card35 = new Card() { Image="9h", Suit =  CardSuit.Diamond, Number = 9 };
            Card card36 = new Card() { Image="10h", Suit =  CardSuit.Diamond, Number = 10 };
            Card card37 = new Card() { Image="11h", Suit =  CardSuit.Diamond, Number = 11 };
            Card card38 = new Card() { Image="12h", Suit =  CardSuit.Diamond, Number = 12 };
            Card card39 = new Card() { Image="13h", Suit =  CardSuit.Diamond, Number = 13 };

            Card card40 = new Card() { Image="1s", Suit =  CardSuit.Club, Number = 1 };
            Card card41 = new Card() { Image="2s", Suit =  CardSuit.Club, Number = 2 };
            Card card42 = new Card() { Image="3s", Suit =  CardSuit.Club, Number = 3 };
            Card card43 = new Card() { Image="4s", Suit =  CardSuit.Club, Number = 4 };
            Card card44 = new Card() { Image="5s", Suit =  CardSuit.Club, Number = 5 };
            Card card45 = new Card() { Image="6s", Suit =  CardSuit.Club, Number = 6 };
            Card card46 = new Card() { Image="7s", Suit =  CardSuit.Club, Number = 7 };
            Card card47 = new Card() { Image="8s", Suit =  CardSuit.Club, Number = 8 };
            Card card48 = new Card() { Image="9s", Suit =  CardSuit.Club, Number = 9 };
            Card card49 = new Card() { Image="10s", Suit =  CardSuit.Club, Number = 10 };
            Card card50 = new Card() { Image="11s", Suit =  CardSuit.Club, Number = 11 };
            Card card51 = new Card() { Image="12s", Suit =  CardSuit.Club, Number = 12 };
            Card card52 = new Card() { Image="13s", Suit =  CardSuit.Club, Number = 13 };

            Card card53 = new Card() { Image="joker", Suit =  CardSuit.Joker, Number = 0 };
            Card card54 = new Card() { Image="joker", Suit =  CardSuit.Joker, Number = 0 };


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
            Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", cardOnHand.Image));
            (rectCardOnHand.Child as Image).Source = new BitmapImage(uri);
            //(rectCardOnHand.Child as TextBlock).Text = cardOnHand.Number.ToString();
        }

        void ShuffleDeck()
        {
            SetupTower(cnvFirst, tower1);
            SetupTower(cnvSecond, tower2);
            SetupTower(cnvThird, tower3);

            SetupDeck(cnvDeck, deck);

            Countdown = 100;
            Stage += 1;

            txtTimer.Text = Countdown.ToString();
            txtPoints.Text = Points.ToString();
            txtStage.Text = Stage.ToString();
        }

        void Reset()
        {
            Points = 0;
            Stage = 0;
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
                    if (tower.Count > crd.Level + 1)
                    {
                        Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/back1.png"));
                        ((canvas.Children[index] as Border).Child as Image).Source = new BitmapImage(uri);
                    }
                    else
                    {
                        Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", card.Image));
                        ((canvas.Children[index] as Border).Child as Image).Source = new BitmapImage(uri);
                    }

                    //((canvas.Children[index] as Border).Child as TextBlock).Text = crd.Card.Number.ToString();
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

                Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", cardOnHand.Image));
                Uri uriTower = null;

                var before = selectedCard.Position > 0 && tower1[selectedCard.Level][selectedCard.Position-1] == null;
                var after = selectedCard.Position < tower1[selectedCard.Level].Count - 1 && tower1[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower1[selectedCard.Level - 1][selectedCard.Position-1].Image));
                    ((cnvFirst.Children[GetChildIndex(selectedCard)] as Border).Child as Image).Source = new BitmapImage(uriTower);
                    //(cnvFirst.Children[GetChildIndex(selectedCard)] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                }
                if (after)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower1[selectedCard.Level - 1][selectedCard.Position].Image));
                    ((cnvFirst.Children[GetChildIndex(selectedCard) + 1] as Border).Child as Image).Source = new BitmapImage(uriTower);
                    //(cnvFirst.Children[GetChildIndex(selectedCard) + 1] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                }

                    tower1[selectedCard.Level][selectedCard.Position] = null;

                    (rectCardOnHand.Child as Image).Source = new BitmapImage(uri);  
                //(rectCardOnHand.Child as TextBlock).Text = selectedCard.Card.Number.ToString();

                    UpdatePoints(tower1, selectedCard);
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

                Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", selectedCard.Card.Image));
                Uri uriTower = null;
                
                var before = selectedCard.Position > 0 && tower2[selectedCard.Level][selectedCard.Position - 1] == null;
                var after = selectedCard.Position < tower2[selectedCard.Level].Count - 1 && tower2[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower2[selectedCard.Level - 1][selectedCard.Position - 1].Image));
                    ((cnvSecond.Children[GetChildIndex(selectedCard)] as Border).Child as Image).Source = new BitmapImage(uriTower);
                    //(cnvSecond.Children[GetChildIndex(selectedCard)] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                }
                if (after)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower2[selectedCard.Level - 1][selectedCard.Position].Image));
                    ((cnvSecond.Children[GetChildIndex(selectedCard) + 1] as Border).Child as Image).Source = new BitmapImage(uriTower);
                    //(cnvSecond.Children[GetChildIndex(selectedCard) + 1] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                }

                tower2[selectedCard.Level][selectedCard.Position] = null;

                (rectCardOnHand.Child as Image).Source = new BitmapImage(uri);
                //(rectCardOnHand.Child as TextBlock).Text = selectedCard.Card.Number.ToString();

                UpdatePoints(tower2, selectedCard);

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
                Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", selectedCard.Card.Image));
                Uri uriTower = null;

                var before = selectedCard.Position > 0 && tower3[selectedCard.Level][selectedCard.Position - 1] == null;
                var after = selectedCard.Position < tower3[selectedCard.Level].Count - 1 && tower3[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower3[selectedCard.Level-1][selectedCard.Position-1].Image));
                    ((cnvThird.Children[GetChildIndex(selectedCard)] as Border).Child as Image).Source = new BitmapImage(uriTower);
                    //(cnvThird.Children[GetChildIndex(selectedCard)] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                }
                if (after)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower3[selectedCard.Level-1][selectedCard.Position].Image));
                    ((cnvThird.Children[GetChildIndex(selectedCard) + 1] as Border).Child as Image).Source = new BitmapImage(uriTower);
                    //(cnvThird.Children[GetChildIndex(selectedCard) + 1] as Border).Background = new SolidColorBrush(new Windows.UI.Color() { R = 180, G = 130, B = 20, A = 255 });
                }

                tower3[selectedCard.Level][selectedCard.Position] = null;

                (rectCardOnHand.Child as Image).Source = new BitmapImage(uri);
                //(rectCardOnHand.Child as TextBlock).Text = selectedCard.Card.Number.ToString();

                UpdatePoints(tower3, selectedCard);
            }

        }

        bool RemoveCard(List<List<Card>> tower, CardIdentifier selectedCard)
        {
            bool result = false;
            //apply the rules to remove a card
            var rule1 = cardOnHand.Number == 0 || selectedCard.Card.Number ==0 || 
                cardOnHand.Number == selectedCard.Card.Number + 1 || cardOnHand.Number == selectedCard.Card.Number - 1;
            var rule2 = tower.Count == selectedCard.Level+1 || 
                (tower[selectedCard.Level + 1][selectedCard.Position] == null && tower[selectedCard.Level + 1][selectedCard.Position + 1] == null);

            result = rule1 && rule2;

            return result; 
        }

        async void UpdatePoints(List<List<Card>> tower, CardIdentifier selectedCard)
        {
            //update points
            var cardsLeft = tower.SelectMany(i => i).Where(t => t != null).ToList();
            var cardsLeftLevel = tower[selectedCard.Level].Where(t => t != null).ToList();
            
            var addition = Stage * 1.5;
            if (cardsLeft.Count == 0)
                Points += (int)(150.00 * addition);
            else if (cardsLeftLevel.Count == 0)
                Points += (int)(20 * addition);
            else
                Points += (int)(10 * addition);

            txtPoints.Text = Points.ToString();

            MessageDialog d = new MessageDialog("Good job");
            if (CheckGameComplete())
                await d.ShowAsync();
        }

        bool CheckGameComplete()
        {
            bool result = false;
            var t1 = tower1.SelectMany(i => i).Where(t => t != null).ToList();
            var t2 = tower2.SelectMany(i => i).Where(t => t != null).ToList();
            var t3 = tower3.SelectMany(i => i).Where(t => t != null).ToList();

            result = t1.Count + t2.Count + t3.Count == 0;

            //btnNextStage.IsEnabled = result;

            return result;
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

            Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", cardOnHand.Image));
            (rectCardOnHand.Child as Image).Source = new BitmapImage(uri);

            //(rectCardOnHand.Child as TextBlock).Text = cardOnHand.Number.ToString();

        }

        private void txtRestart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Reset();
            InitCards();
            ShuffleDeck();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            Countdown--;
            txtTimer.Text = Countdown.ToString();

            if (Countdown <= 0)
            {
                this.dispatcherTimer.Stop();
                this.dispatcherTimer = null;
            }
        }

        private void btnStart_Tapped(object sender, RoutedEventArgs e)
        {
            if (this.dispatcherTimer == null)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler<object>(dispatcherTimer_Tick);
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            }

            this.dispatcherTimer.Start();
        }

        private void btnNextStage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InitCards();
            ShuffleDeck();
        }
    }
}
