<<<<<<< HEAD
﻿#pragma checksum "..\..\EditReminder.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4AC9C2D12AE74EAA6C404896FDFB199B"
=======
﻿#pragma checksum "..\..\EditReminder.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EE0EE283E7D87348D9C5C966FFF69BCD"
>>>>>>> 8ffaa30567c1d1502d340cd733961074fa6751aa
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
    /// EditReminder
    /// </summary>
    public partial class EditReminder : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleForReminder;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox starttid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox alarmtid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox mondaybox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox tuesdaybox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox wednesdaybox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox thursdaybox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox fridaybox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox saturdaybox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox sundaybox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\EditReminder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editReminder;
        
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
            System.Uri resourceLocater = new System.Uri("/guiprojekt;component/editreminder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditReminder.xaml"
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
            
            #line 12 "..\..\EditReminder.xaml"
            this.titleForReminder.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.testInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.starttid = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\EditReminder.xaml"
            this.starttid.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.testInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.alarmtid = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\EditReminder.xaml"
            this.alarmtid.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.testInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mondaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 54 "..\..\EditReminder.xaml"
            this.mondaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tuesdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 55 "..\..\EditReminder.xaml"
            this.tuesdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.wednesdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\EditReminder.xaml"
            this.wednesdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.thursdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\EditReminder.xaml"
            this.thursdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.fridaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 58 "..\..\EditReminder.xaml"
            this.fridaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.saturdaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 59 "..\..\EditReminder.xaml"
            this.saturdaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sundaybox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 60 "..\..\EditReminder.xaml"
            this.sundaybox.Click += new System.Windows.RoutedEventHandler(this.testRoutedInput);
            
            #line default
            #line hidden
            return;
            case 11:
            this.editReminder = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\EditReminder.xaml"
            this.editReminder.Click += new System.Windows.RoutedEventHandler(this.editReminder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

