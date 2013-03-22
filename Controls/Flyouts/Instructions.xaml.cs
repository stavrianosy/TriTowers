﻿using System;
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
    public sealed partial class Instructions : UserControl
    {
        public delegate void ContinueDelegate();
        public event ContinueDelegate ContinueEvent;

        public delegate void CancelDelegate();
        public event CancelDelegate CancelEvent;

        public Instructions()
        {
            this.InitializeComponent();
        }

        private void btnContinue_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContinueEvent();
        }

        private void btnCancel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CancelEvent();
        }
    }
}