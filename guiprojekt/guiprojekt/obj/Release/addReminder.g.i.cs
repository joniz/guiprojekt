﻿#pragma checksum "..\..\addReminder.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "36D26D489B4CBAC7A08B6B49FC97AD55"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace guiprojekt {
    
    
    /// <summary>
    /// addReminder
    /// </summary>
    public partial class addReminder : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleForReminder;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox starttid;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox alarmtid;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox mondaybox;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox tuesdaybox;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox wednesdaybox;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox thursdaybox;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox fridaybox;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox saturdaybox;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox sundaybox;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\addReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createReminder;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/guiprojekt;component/addreminder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\addReminder.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.titleForReminder = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\addReminder.xaml"
            this.titleForReminder.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.testInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.starttid = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\addReminder.xaml"
            this.starttid.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.testInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.alarmtid = ((System.Windows.Controls.TextBox)(target));
            
            #line 89 "..\..\addReminder.xaml"
            this.alarmtid.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.testInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mondaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 115 "..\..\addReminder.xaml"
            this.mondaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tuesdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 116 "..\..\addReminder.xaml"
            this.tuesdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.wednesdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 117 "..\..\addReminder.xaml"
            this.wednesdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.thursdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 118 "..\..\addReminder.xaml"
            this.thursdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.fridaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 119 "..\..\addReminder.xaml"
            this.fridaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.saturdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 120 "..\..\addReminder.xaml"
            this.saturdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sundaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 121 "..\..\addReminder.xaml"
            this.sundaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 11:
            this.createReminder = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\addReminder.xaml"
            this.createReminder.Click += new System.Windows.RoutedEventHandler(this.createReminder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

