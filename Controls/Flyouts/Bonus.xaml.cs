using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TriTowers.Controls.Flyouts
{
    public sealed partial class Bonus : UserControl
    {
        public delegate void ContinueDelegate();
        public event ContinueDelegate ContinueEvent;

        public int Stage
        {
            get { return (int)GetValue(StageProperty); }
            set { SetValue(StageProperty, value); }
        }

        public int TotalScore
        {
            get { return (int)GetValue(TotalScoreProperty); }
            set { SetValue(TotalScoreProperty, value); }
        }

        public int Level1
        {
            get { return (int)GetValue(Level1Property); }
            set { SetValue(Level1Property, value); }
        }

        public int Level2
        {
            get { return (int)GetValue(Level2Property); }
            set { SetValue(Level2Property, value); }
        }

        public int Level3
        {
            get { return (int)GetValue(Level3Property); }
            set { SetValue(Level3Property, value); }
        }


        public static readonly DependencyProperty StageProperty =
            DependencyProperty.Register("Stage", typeof(int), typeof(Bonus), new PropertyMetadata(null));

        public static readonly DependencyProperty TotalScoreProperty =
            DependencyProperty.Register("TotalScore", typeof(int), typeof(Bonus), new PropertyMetadata(null));

        public static readonly DependencyProperty Level1Property =
            DependencyProperty.Register("Level1", typeof(int), typeof(Bonus), new PropertyMetadata(null));

        public static readonly DependencyProperty Level2Property =
            DependencyProperty.Register("Level2", typeof(int), typeof(Bonus), new PropertyMetadata(null));

        public static readonly DependencyProperty Level3Property =
            DependencyProperty.Register("Level3", typeof(int), typeof(Bonus), new PropertyMetadata(null));


        public Bonus()
        {
            this.InitializeComponent();
        }

        private void btnContinue_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContinueEvent();
        }
    }
}
