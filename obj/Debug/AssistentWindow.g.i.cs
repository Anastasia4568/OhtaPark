﻿#pragma checksum "..\..\AssistentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD79B9F10A8684A5D40F35BC4B2AAE851B9DC810F482F598E89CD0264929D28A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Okhta_Park;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Okhta_Park {
    
    
    /// <summary>
    /// AssistentWindow
    /// </summary>
    public partial class AssistentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectClientButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddClientButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ClientOutput;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateStartInput;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeInput;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddOrderButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearOrderButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Services;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddServiceButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteServiceButton;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\AssistentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimerOutput;
        
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
            System.Uri resourceLocater = new System.Uri("/Okhta Park;component/assistentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AssistentWindow.xaml"
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
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\AssistentWindow.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SelectClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\AssistentWindow.xaml"
            this.SelectClientButton.Click += new System.Windows.RoutedEventHandler(this.SelectClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\AssistentWindow.xaml"
            this.AddClientButton.Click += new System.Windows.RoutedEventHandler(this.AddClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ClientOutput = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DateStartInput = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.TimeInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 65 "..\..\AssistentWindow.xaml"
            this.TimeInput.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TimeInput_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AddOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\AssistentWindow.xaml"
            this.AddOrderButton.Click += new System.Windows.RoutedEventHandler(this.AddOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ClearOrderButton = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\AssistentWindow.xaml"
            this.ClearOrderButton.Click += new System.Windows.RoutedEventHandler(this.ClearOrderButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Services = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.AddServiceButton = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\AssistentWindow.xaml"
            this.AddServiceButton.Click += new System.Windows.RoutedEventHandler(this.AddServiceButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.DeleteServiceButton = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\AssistentWindow.xaml"
            this.DeleteServiceButton.Click += new System.Windows.RoutedEventHandler(this.DeleteServiceButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.TimerOutput = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
