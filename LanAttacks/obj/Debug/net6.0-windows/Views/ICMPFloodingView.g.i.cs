﻿#pragma checksum "..\..\..\..\Views\ICMPFloodingView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0867316748696C8BD509F368482F732AA9EA3C12"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using LanAttacks.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LanAttacks.Views {
    
    
    /// <summary>
    /// ICMPFloodingView
    /// </summary>
    public partial class ICMPFloodingView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Views\ICMPFloodingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountOfPackets;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\ICMPFloodingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DstFirstOctet;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\ICMPFloodingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DstSecondOctet;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\ICMPFloodingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DstThirdOctet;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\ICMPFloodingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DstFourthOctet;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\ICMPFloodingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ResultLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LanAttacks;component/views/icmpfloodingview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ICMPFloodingView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AmountOfPackets = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.AmountOfPackets.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.AmountOfPackets.LostFocus += new System.Windows.RoutedEventHandler(this.AmountInput_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DstFirstOctet = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstFirstOctet.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstFirstOctet.LostFocus += new System.Windows.RoutedEventHandler(this.IpInputLostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DstSecondOctet = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstSecondOctet.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstSecondOctet.LostFocus += new System.Windows.RoutedEventHandler(this.IpInputLostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DstThirdOctet = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstThirdOctet.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstThirdOctet.LostFocus += new System.Windows.RoutedEventHandler(this.IpInputLostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DstFourthOctet = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstFourthOctet.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\..\Views\ICMPFloodingView.xaml"
            this.DstFourthOctet.LostFocus += new System.Windows.RoutedEventHandler(this.IpInputLostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 39 "..\..\..\..\Views\ICMPFloodingView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ICMPSubmit_Clicked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ResultLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

