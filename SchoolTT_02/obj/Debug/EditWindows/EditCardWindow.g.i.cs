﻿#pragma checksum "..\..\..\EditWindows\EditCardWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DB999CC4C9F9A5326B12AA53A8010913603D8DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SchoolTT_02;
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


namespace SchoolTT_02 {
    
    
    /// <summary>
    /// EditCardWindow
    /// </summary>
    public partial class EditCardWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WindowFirstName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WindowSecondName;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WindowThirdName;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox WindowClass;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WindowDiscipline;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WindowCount;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\EditWindows\EditCardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WindowBackground;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolTT_02;component/editwindows/editcardwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditWindows\EditCardWindow.xaml"
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
            
            #line 8 "..\..\..\EditWindows\EditCardWindow.xaml"
            ((SchoolTT_02.EditCardWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.EditCardWindow_OnClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.WindowFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.WindowSecondName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.WindowThirdName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.WindowClass = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.WindowDiscipline = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.WindowCount = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\EditWindows\EditCardWindow.xaml"
            this.WindowCount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.WindowCount_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.WindowBackground = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\EditWindows\EditCardWindow.xaml"
            this.WindowBackground.Click += new System.Windows.RoutedEventHandler(this.ColorPickerClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 58 "..\..\..\EditWindows\EditCardWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AcceptClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

