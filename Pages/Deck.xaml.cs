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

using TriTowers.ViewModel;
using TriTowers.Common;
using TriTowers.DataModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TriTowers.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Deck : LayoutAwarePage
    {
        Card cardOnHand;

        List<List<Card>> tower1;
        List<List<Card>> tower2;
        List<List<Card>> tower3;

        List<Card> deck;

        DispatcherTimer dispatcherTimer;
        DispatcherTimer hideCardsTimer;

        InGame inGame;

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
            flyStartGame.StartGameEvent += flyStartGame_Continue;
            flyRestartGame.ContinueEvent += flyRestartGame_Continue;
            flyRestartGame.CancelEvent += flyRestartGame_Cancel;
            flyNextRound.ContinueEvent += flyNextRound_Continue;
            flyBonus.ContinueEvent += flyBonus_Continue;
            flyLostBonus.ContinueEvent += flyLostBonus_Continue;
            flyLostGame.ContinueEvent += flyLostGame_Continue;
            flyFinishedGame.ContinueEvent += flyFinishedGame_Continue;
            flyFinishedGameWithHiScore.ContinueEvent += flyFinishedGameWithHiScore_Continue;
            flyInstructions.ContinueEvent += flyInstructions_Continue;
            flyInstructions.CancelEvent += flyInstructions_Cancel;

            flyStartGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyRestartGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyNextRound.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyBonus.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyLostBonus.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyLostGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyFinishedGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyFinishedGameWithHiScore.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            flyInstructions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            inGame = new InGame();
            
            DisplayFlyout_StartGame();

            this.DefaultViewModel["Items"] = inGame;

            if (this.dispatcherTimer == null)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler<object>(dispatcherTimer_Tick);
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            }

            this.dispatcherTimer.Start();

            PauseGame();
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

            List<Card> tempCard = new List<Card>() { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10,
                                                     card11, card12, card13, card14, card15, card16, card17, card18, card19, card20,
                                                     card21, card22, card23, card24, card25, card26, card27, card28, card29, card30,
                                                     card31, card32, card33, card34, card35, card36, card37, card38, card39, card40,
                                                     card41, card42, card43, card44, card45, card46, card47, card48, card49, card50,
                                                     card51, card52, card53, card54};

            //## Add a method to mix cards #//
            //List<Card> level1_1 = new List<Card>() { GetRandomCards(ref tempCard) };
            //List<Card> level1_2 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level1_3 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level1_4 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level1_5 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };

            //List<Card> level2_1 = new List<Card>() { GetRandomCards(ref tempCard) };
            //List<Card> level2_2 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level2_3 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level2_4 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level2_5 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };

            //List<Card> level3_1 = new List<Card>() { GetRandomCards(ref tempCard) };
            //List<Card> level3_2 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level3_3 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level3_4 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            //List<Card> level3_5 = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };

            List<Card> level1_1 = new List<Card>() { card1 };
            List<Card> level1_2 = new List<Card>() { card2, card3 };
            List<Card> level1_3 = new List<Card>() { card4, card5, card6 };
            List<Card> level1_4 = new List<Card>() { card7, card8, card9, card10, };
            List<Card> level1_5 = new List<Card>() { card11, card12, card13, card14, card15, };

            List<Card> level2_1 = new List<Card>() { card16 };
            List<Card> level2_2 = new List<Card>() { card17, card18, };
            List<Card> level2_3 = new List<Card>() { card19, card20, card21 };
            List<Card> level2_4 = new List<Card>() { card22, card23, card24, card25 };
            List<Card> level2_5 = new List<Card>() { card26, card27, card28, card29, card30 };

            List<Card> level3_1 = new List<Card>() { card31 };
            List<Card> level3_2 = new List<Card>() { card32, card33 };
            List<Card> level3_3 = new List<Card>() { card34, card35, card36 };
            List<Card> level3_4 = new List<Card>() { card37, card38, card39, card40 };
            List<Card> level3_5 = new List<Card>() { card41, card42, card43, card44, card45 };

            //deck = new List<Card>() { GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard), GetRandomCards(ref tempCard) };
            deck = new List<Card>() { card53, card53, card53, card53, card53, card53, card53, card53 };
            
            //Card on hand
            //cardOnHand = GetRandomCards(ref tempCard);
            cardOnHand = card53;
            //## ###################### #//

            //ListOfLevels
            tower1 = new List<List<Card>>() { level1_1, level1_2, level1_3, level1_4, level1_5 };
            tower2 = new List<List<Card>>() { level2_1, level2_2, level2_3, level2_4, level2_5 };
            tower3 = new List<List<Card>>() { level3_1, level3_2, level3_3, level3_4, level3_5 };

            Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", cardOnHand.Image));
            (rectCardOnHand as Image).Source = new BitmapImage(uri);
        }

        Card GetRandomCards(ref List<Card> cards)
        {
            var random = new Random();
            var result = new Card();

            var index = random.Next(cards.Count());
            result = cards[index];
            cards.RemoveAt(index);

            return result;
        }

        void ShuffleDeck()
        {
            SetupTower(cnvFirst, tower1);
            SetupTower(cnvSecond, tower2);
            SetupTower(cnvThird, tower3);

            SetupDeck(cnvDeck, deck);

            if(inGame.IsBonusStage)
                txtTimer.Text = inGame.BonusCountdown.ToString();
            else
                txtTimer.Text = inGame.Countdown.ToString();
            
            txtPoints.Text = inGame.Points.ToString();
            txtStage.Text = inGame.Stage.ToString();
        }

        void Reset()
        {
            try
            {
                inGame = new InGame();
                inGame.HiScore = App.Instance.GameDataSource.GameStats.Score;
                inGame.HiScoreDate = App.Instance.GameDataSource.GameStats.Date;

                txtHiScore.Text = inGame.HiScore.ToString();
                txtHiScoreDate.Text = inGame.HiScoreDate.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {                
                throw;
            }
        }

        private void SetupDeck(Canvas canvas, List<Card> deck)
        {
            var index = 0;
            //##Setup deck
            foreach (var card in deck)
            {
                var crd = new CardIdentifier() { CardIdentifierId = index, Level = 0, Card = card, Position = index };
                (canvas.Children[index] as Image).Tag = crd;
                (canvas.Children[index] as Image).Margin = new Thickness(0);
                index++;
            }
            inGame.CardsOnHand = index;
            txtCardsLeft.Text = inGame.CardsOnHand.ToString(); 
        }

        void SetupTower(Canvas canvas, List<List<Card>> tower)
        {
            
            var index = 0;
            var levelIndex = 0;
            //#Setup towers
            foreach (var level in tower)
            {
                var position = 0;
                foreach (var card in level)
                {
                    var crd = new CardIdentifier() { CardIdentifierId = index, Level = levelIndex, Card = card, Position = position };
                    (canvas.Children[index] as Image).Tag = crd;
                    (canvas.Children[index] as Image).Margin = new Thickness(0);
                    
                    Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", card.Image));
                    (canvas.Children[index] as Image).Source = new BitmapImage(uri);

                    index++;
                    position++;
                }
                levelIndex++;
            }

        }

        private void cardTower1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog dialog = null;

            if (inGame.DisableCardClick || inGame.GameIsPaused)
                return;

            var card = (sender as Image);
            var selectedCard = card.Tag as CardIdentifier;
            var remove = RemoveCard(tower1, selectedCard);
            if (remove)
            {
                inGame.HitsInRowCount++;
                card.Margin = new Thickness(0, -1000, 0, 0);
                cardOnHand = selectedCard.Card;

                Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", cardOnHand.Image));
                Uri uriTower = null;

                var before = selectedCard.Position > 0 && tower1[selectedCard.Level][selectedCard.Position-1] == null;
                var after = selectedCard.Position < tower1[selectedCard.Level].Count - 1 && tower1[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower1[selectedCard.Level - 1][selectedCard.Position-1].Image));
                    (cnvFirst.Children[GetChildIndex(selectedCard)] as Image).Source = new BitmapImage(uriTower);
                }
                if (after)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower1[selectedCard.Level - 1][selectedCard.Position].Image));
                    (cnvFirst.Children[GetChildIndex(selectedCard) + 1] as Image).Source = new BitmapImage(uriTower);
                }

                    tower1[selectedCard.Level][selectedCard.Position] = null;

                    (rectCardOnHand as Image).Source = new BitmapImage(uri);  

                    UpdatePoints(tower1, selectedCard);
                    CheckForBonus();
            }

        }

        private void cardTower2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (inGame.DisableCardClick || inGame.GameIsPaused)
                return;

            var card = (sender as Image);
            var selectedCard = card.Tag as CardIdentifier;
            var b = RemoveCard(tower2 , selectedCard);
            if (b)
            {
                inGame.HitsInRowCount++;
                card.Margin = new Thickness(0, -1000, 0, 0);
                cardOnHand = selectedCard.Card;

                Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", selectedCard.Card.Image));
                Uri uriTower = null;

                var before = selectedCard.Position > 0 && tower2[selectedCard.Level][selectedCard.Position - 1] == null;
                var after = selectedCard.Position < tower2[selectedCard.Level].Count - 1 && tower2[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower2[selectedCard.Level - 1][selectedCard.Position - 1].Image));
                    (cnvSecond.Children[GetChildIndex(selectedCard)] as Image).Source = new BitmapImage(uriTower);
                }
                if (after)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower2[selectedCard.Level - 1][selectedCard.Position].Image));
                    (cnvSecond.Children[GetChildIndex(selectedCard) + 1] as Image).Source = new BitmapImage(uriTower);
                }

                tower2[selectedCard.Level][selectedCard.Position] = null;

                (rectCardOnHand as Image).Source = new BitmapImage(uri);

                UpdatePoints(tower2, selectedCard);
                CheckForBonus();
            }
        }

        private void cardTower3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (inGame.DisableCardClick || inGame.GameIsPaused)
                return;

            var card = (sender as Image);
            var selectedCard = card.Tag as CardIdentifier;
            var b = RemoveCard(tower3, selectedCard);
            if (b)
            {
                inGame.HitsInRowCount++;
                card.Margin = new Thickness(0, -1000, 0, 0);
                cardOnHand = selectedCard.Card;
                Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", selectedCard.Card.Image));
                Uri uriTower = null;

                var before = selectedCard.Position > 0 && tower3[selectedCard.Level][selectedCard.Position - 1] == null;
                var after = selectedCard.Position < tower3[selectedCard.Level].Count - 1 && tower3[selectedCard.Level][selectedCard.Position + 1] == null;

                if (before)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower3[selectedCard.Level - 1][selectedCard.Position - 1].Image));
                    (cnvThird.Children[GetChildIndex(selectedCard)] as Image).Source = new BitmapImage(uriTower);
                }
                if (after)
                {
                    uriTower = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", tower3[selectedCard.Level - 1][selectedCard.Position].Image));
                    (cnvThird.Children[GetChildIndex(selectedCard) + 1] as Image).Source = new BitmapImage(uriTower);
                }

                tower3[selectedCard.Level][selectedCard.Position] = null;

                (rectCardOnHand as Image).Source = new BitmapImage(uri);

                UpdatePoints(tower3, selectedCard);

                CheckForBonus();
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

        void UpdatePoints(List<List<Card>> tower, CardIdentifier selectedCard)
        {
            //update points
            var cardsLeft = tower.SelectMany(i => i).Where(t => t != null).ToList();
            var cardsLeftLevel = tower[selectedCard.Level].Where(t => t != null).ToList();

            var points = 0;
            var addition = inGame.Stage * 1.5;
            points = (int)(10 * addition);
            //inGame.Points += (int)(10 * addition);

            //## idea 1            
            //if (cardsLeft.Count == 0)
            //    inGame.Points += (int)(150.00 * addition);
            //else if (cardsLeftLevel.Count == 0)
            //    inGame.Points += (int)(20 * addition);
            //else
            //    inGame.Points += (int)(10 * addition);

            //## idea 2
            if (cardsLeftLevel.Count == 0)
            {
                switch (selectedCard.Level)
                {
                    case 2:
                        points += inGame.Level3Points;
                        inGame.Level3Count++;
                        break;
                    case 1:
                        points += inGame.Level2Points;
                        inGame.Level2Count++;
                        break;
                    case 0:
                        points += inGame.Level1Points;
                        inGame.Level1Count++;
                        break;
                    default:
                        break;
                }
            }

            inGame.TotalStagePoints += points;
            inGame.Points += points;
            
            txtPoints.Text = inGame.Points.ToString();

            MessageDialog d = new MessageDialog("Good job");
            if (CheckGameComplete())
            {
                inGame.StopTime = true;
                if (inGame.NextRoundCount > 0)
                {
                    DisplayFlyout_Bonus();
                }
                else
                {
                    ///await d.ShowAsync(); 
                    DisplayFlyout_NextRound();
                }

                if (!inGame.IsBonusStage)
                {
                    inGame.Stage++;
                }
            }
        }

        void CheckForBonus()
        {
            //Clear all bonuses if continues hit is 0
            if (inGame.HitsInRowCount == 0)
            {
                inGame.FreezeCount = inGame.NextRoundCount = 0;
                txtFreeze.Foreground = txtBonus.Foreground = inGame.TextDisabledColor;
            }

            //skip all bonuses if already in a bonus stage
            if (inGame.IsBonusStage)
                return;

            //Freeze
            if (inGame.HitsInRowCount > 0 && inGame.HitsInRowCount % inGame.FreezeSet == 0)
            {
                inGame.FreezeCount++;
                if (inGame.FreezeCount == inGame.FreezeSet)
                {
                    inGame.IsFreezed = true;
                    inGame.FreezeForSecs += inGame.FreezeDuration;
                    txtFreeze.Foreground = inGame.FreezeColor;
                    inGame.FreezeCount = 0;
                }
            }

            //NextRound
            if (inGame.HitsInRowCount > 0 && inGame.HitsInRowCount % inGame.NextRoundSet == 0)
            {
                inGame.NextRoundCount++;
                if (inGame.NextRoundCount > 0)
                {
                    txtBonus.Foreground = inGame.NextRoundColor;
                }
            }
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
            if (inGame.DisableCardClick || inGame.GameIsPaused)
                return;

            var card = (sender as Image);
            var selectedCard = card.Tag as CardIdentifier;

            card.Margin = new Thickness(0, -1000, 0, 0);
            cardOnHand = selectedCard.Card;

            Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/{0}.png", cardOnHand.Image));
            (rectCardOnHand as Image).Source = new BitmapImage(uri);

            inGame.CardsOnHand--;
            txtCardsLeft.Text = inGame.CardsOnHand.ToString();

            inGame.HitsInRowCount = 0;
            //inGame.FreezeCount = inGame.NextRoundCount = 0;
            inGame.NextRoundCount = 0;
            //CheckForBonus();
        }

        private void btnStart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DisplayFlyout_StartGame();            
        }

        private void DisplayFlyout_StartGame()
        {
            PauseGame();
            flyStartGame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyStartGame.Margin = new Thickness(300, 200, 0, 0);
        }

        private void DisplayFlyout_NextRound()
        {
            PauseGame();
            flyNextRound.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyNextRound.Margin = new Thickness(300, 200, 0, 0);
        }
        
        private void DisplayFlyout_Bonus()
        {
            PauseGame();
            flyBonus.Stage = inGame.Stage;
            flyBonus.TotalScore = inGame.TotalStagePoints;
            flyBonus.Level1 = inGame.Level1Count;
            flyBonus.Level2 = inGame.Level2Count;
            flyBonus.Level3 = inGame.Level3Count;
            flyBonus.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyBonus.Margin = new Thickness(300, 150, 0, 0);
        }

        private void DisplayFlyout_LostBonus()
        {
            PauseGame();
            flyLostBonus.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyLostBonus.Margin = new Thickness(300, 200, 0, 0);
        }

        private void DisplayFlyout_LostGame()
        {
            PauseGame();
            flyLostGame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyLostGame.Margin = new Thickness(300, 200, 0, 0);
        }
        
        private void DisplayFlyout_FinishedGame()
        {
            PauseGame();
            flyFinishedGame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyFinishedGame.Margin = new Thickness(300, 200, 0, 0);
        }

        private void DisplayFlyout_FinishedGameWithHiScore()
        {
            PauseGame();
            flyFinishedGameWithHiScore.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyFinishedGameWithHiScore.Margin = new Thickness(300, 200, 0, 0);
        }



        private void DisplayFlyout_RestartGame()
        {
            PauseGame();
            flyRestartGame.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyRestartGame.Margin = new Thickness(300, 200, 0, 0);
        }

        private void DisplayFlyout_Instructions()
        {
            PauseGame();
            flyInstructions.Visibility = Windows.UI.Xaml.Visibility.Visible;
            flyInstructions.Margin = new Thickness(300, 200, 0, 0);
        }

        void flyStartGame_Continue()
        {
            flyStartGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            StartGame();
        }
        void flyNextRound_Continue()
        {
            flyNextRound.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            NextStage();
        }
        
        void flyBonus_Continue()
        {
            flyBonus.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;
            
            NextStage();
        }

        void flyLostBonus_Continue()
        {
            flyLostBonus.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            NextStage();
        }
        void flyLostGame_Continue()
        {
            flyLostGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            NextStage();
        }

        void flyFinishedGame_Continue()
        {
            flyFinishedGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            StartGame();
        }

        void flyFinishedGameWithHiScore_Continue()
        {
            flyFinishedGameWithHiScore.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            StartGame();
        }


        void flyRestartGame_Continue()
        {
            flyRestartGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            StartGame();
        }
        void flyRestartGame_Cancel()
        {
            flyRestartGame.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            UnPauseGame();
        }

        void flyInstructions_Continue()
        {
            flyInstructions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            inGame.GameIsPaused = false;

            Frame.Navigate(typeof(Pages.Instructions));
        }

        void flyInstructions_Cancel()
        {
            flyInstructions.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            UnPauseGame();
        }

        private void StartGame()
        {
            Reset();
            NextStage();
        }

        private void NextStage()
        {
            inGame.DisableCardClick = true;

            //#apply NextRound bonus
            if (inGame.NextRoundCount == 0)
                inGame.IsBonusStage = false;
            else
                inGame.IsBonusStage = true;

            txtStage.Text = inGame.Stage.ToString();
            txtChances.Text = inGame.Chances.ToString();
            txtFreeze.Foreground = inGame.TextDisabledColor;
            txtBonus.Foreground = inGame.TextDisabledColor;

            if (!inGame.IsBonusStage)
                inGame.Countdown += inGame.ExtratimeOnStage;
            

            InitCards();
            ShuffleDeck();

            //apply NextRound bonus
            if (!inGame.IsBonusStage)
            {
                inGame.StopTime = true;
                if (this.hideCardsTimer == null)
                {
                    hideCardsTimer = new DispatcherTimer();
                    hideCardsTimer.Tick += new EventHandler<object>(hideCardsTimer_Tick);
                    hideCardsTimer.Interval = TimeSpan.FromSeconds(inGame.ShowCardsFor - inGame.Stage);
                }

                this.hideCardsTimer.Start();
            }
            else
            {
                inGame.StopTime = false;
                inGame.DisableCardClick = false;
            }

            inGame.BonusCountdown = inGame.BonusDuration;
            inGame.HitsInRowCount = 0;
            inGame.NextRoundCount = 0;
            inGame.FreezeCount = 0;
            inGame.IsFreezed = false;
            inGame.TotalStagePoints = 0;

        }

        void PauseGame()
        {
            inGame.DisableCardClick = true;
            inGame.StopTime = true;
            inGame.GameIsPaused = true;
        }

        void UnPauseGame()
        {
            inGame.DisableCardClick = false;
            inGame.StopTime = false;
            inGame.GameIsPaused = false;
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            //if(inGame.DisableCardClick && !inGame.IsBonusStage)
            //    return;

            if (inGame.StopTime || inGame.GameIsPaused)
                return;

            //##apply freeze bonus
            if (inGame.IsFreezed)
            {
                inGame.FreezeForSecs--;
                //##reset after freeze is done
                if (inGame.FreezeForSecs <= 0)
                {
                    inGame.FreezeCount = 0;
                    inGame.IsFreezed = false;
                    txtFreeze.Foreground = inGame.TextDisabledColor;
                }
                return;
            }

            if (!inGame.IsBonusStage)
            {
                inGame.Countdown--;
                txtTimer.Text = inGame.Countdown.ToString();
            }
            else
            {
                inGame.BonusCountdown--;
                txtTimer.Text = inGame.BonusCountdown.ToString();
            }

            if (inGame.Countdown <= 0 || inGame.BonusCountdown <= 0)
            {
                inGame.StopTime = true;

                if (inGame.IsBonusStage)
                    BonusLost();
                else
                    if (inGame.Chances > 0)
                        GameLost();
                    else
                        GameFinished();
            }
        }

        private void BonusLost()
        {
            //restart the game
            MessageDialog dialog = new MessageDialog("Your time is up! Press Close to continue to next stage", "Time Up");
            //dialog.ShowAsync();
            DisplayFlyout_LostBonus();
            //StartGame();
        }

        void hideCardsTimer_Tick(object sender, object e)
        {
            this.hideCardsTimer.Stop();
            this.hideCardsTimer = null;

            var cardsToHide1 = tower1.GetRange(0, tower1.Count - 1).SelectMany(c => c);
            var cardsToHide2 = tower2.GetRange(0, tower2.Count - 1).SelectMany(c => c);
            var cardsToHide3 = tower3.GetRange(0, tower3.Count - 1).SelectMany(c => c);

            Uri uri = new Uri(string.Format("ms-appx:///Assets/Cards/back1.png"));

            for (int i = 0; i < cardsToHide1.Count(); i++)
                (cnvFirst.Children[i] as Image).Source = new BitmapImage(uri);

            for (int i = 0; i < cardsToHide2.Count(); i++)
                (cnvSecond.Children[i] as Image).Source = new BitmapImage(uri);

            for (int i = 0; i < cardsToHide1.Count(); i++)
                (cnvThird.Children[i] as Image).Source = new BitmapImage(uri);

            inGame.DisableCardClick = false;
            inGame.StopTime = false;
        }

        private async void GameFinished()
        {
            if (inGame.Points > inGame.HiScore)
            {
                var game = new GameItem() { Score = inGame.Points, Date = DateTime.Now };
                await App.Instance.GameDataSource.SaveGameStats(game);

                inGame.HiScore = game.Score;
                inGame.HiScoreDate = game.Date;

                txtHiScore.Text = inGame.HiScore.ToString();
                txtHiScoreDate.Text = inGame.HiScoreDate.ToString("dd/MM/yyyy");

                DisplayFlyout_FinishedGameWithHiScore();
            }
            else
                DisplayFlyout_FinishedGame();
        }

        private void GameLost()
        {
            //restart the game
            DisplayFlyout_LostGame();

            inGame.Countdown = inGame.InitialTime;
            inGame.Chances--;

            txtStage.Text = inGame.Stage.ToString();
            txtChances.Text = inGame.Chances.ToString();

            //StartGame();
        }

        private void btnInstructions_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DisplayFlyout_Instructions();
        }

        private void btnRestart_Tapped(object sender, TappedRoutedEventArgs e)
        {
            DisplayFlyout_RestartGame();
        }

    }
}
