﻿#pragma checksum "..\..\..\NewGameWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5BEC069BA1F1957180E02E2D30EF22C4D6957823"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NI_Fonakolos_játék;
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


namespace NI_Fonakolos_játék {
    
    
    /// <summary>
    /// NewGameWindow
    /// </summary>
    public partial class NewGameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CvsP_cmp;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PvsP;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitBTN;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Player1_box;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Player2_box;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button playBTN;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Player2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\NewGameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Player1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NI_Fonakolos_játék;component/newgamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NewGameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CvsP_cmp = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\NewGameWindow.xaml"
            this.CvsP_cmp.Click += new System.Windows.RoutedEventHandler(this.CvsP_clicked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PvsP = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\NewGameWindow.xaml"
            this.PvsP.Click += new System.Windows.RoutedEventHandler(this.PvsP_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.exitBTN = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\NewGameWindow.xaml"
            this.exitBTN.Click += new System.Windows.RoutedEventHandler(this.exitBTN_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Player1_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Player2_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.playBTN = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\NewGameWindow.xaml"
            this.playBTN.Click += new System.Windows.RoutedEventHandler(this.playBTN_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Player2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Player1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

