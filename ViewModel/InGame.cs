using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriTowers.Common;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace TriTowers.ViewModel
{
    public class InGame:BindableBase
    {
        private  int countdown;
        private int points;
        private int stage;
        private int cardsOnHand;
        private int chances;
        private bool nextRound;
        private bool freeze;

        public int Countdown { get { return countdown; } set { countdown = value; } }
        public int InitialTime { get; set; }
        public int ExtratimeOnStage { get; set; }
        public int Points { get { return points; } set { points = value;OnPropertyChanged("Points"); } }
        public int Stage { get; set; }
        public int CardsOnHand { get; set; }
        public int Chances { get; set; }
        public bool NextRound { get; set; }
        public bool Freeze { get; set; }
        public bool DisableCardClick { get; set; }
        public bool IsBonusStage { get; set; }
        public int NextRoundCount { get; set; }
        public int NextRoundSet { get; set; }
        public int BonusDuration { get; set; }
        public int BonusCountdown { get; set; }
        public SolidColorBrush NextRoundColor { get; set; }
        public int FreezeCount { get; set; }
        public int FreezeSet { get; set; }
        public int FreezeDuration { get; set; }
        public int FreezeForSecs { get; set; }
        public bool IsFreezed { get; set; }
        public SolidColorBrush FreezeColor { get; set; }
        public int HitsInRowCount { get; set; }
        public SolidColorBrush TextDisabledColor { get; set; }
        public bool StopTime { get; set; }
        public bool GameIsPaused { get; set; }
        public int ShowCardsFor { get; set; }
        public int HiScore { get; set; }
        public DateTime HiScoreDate { get; set; }
        
        public InGame()
        {
            Points = 0;
            Stage = 1;
            CardsOnHand = 0;
            Chances = 2;
            InitialTime = 50;
            ExtratimeOnStage = -30;
            Countdown = InitialTime;
            NextRoundCount = 0;
            FreezeCount = 0;
            FreezeSet = 3;
            FreezeDuration = 5;
            FreezeForSecs = 0;
            IsFreezed = false;
            HitsInRowCount = 0;
            NextRoundSet = 12;
            FreezeColor = new SolidColorBrush(new Color() { R = 30, G = 35, B = 145, A = 255 });
            NextRoundColor = new SolidColorBrush(new Color() { R = 145, G = 30, B = 30, A = 255 });
            TextDisabledColor = new SolidColorBrush(new Color() { R = 165, G = 165, B = 165, A = 255 });
            DisableCardClick = true;
            IsBonusStage = false;
            BonusDuration = 50;
            StopTime = false;
            GameIsPaused = false;
            ShowCardsFor = 5;
            HiScore = 0;
            HiScoreDate = DateTime.Now;
        }
    }

}
