﻿#pragma checksum "..\..\..\Pages\Authorisation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7BD2ABAF0AFC9CE6D514B736F0D205592BDF21FB93DF8FF2E3E44733CFCAF41C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Lapshin_FitnessClub.Pages;
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


namespace Lapshin_FitnessClub.Pages {
    
    
    /// <summary>
    /// Authorisation
    /// </summary>
    public partial class Authorisation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\Pages\Authorisation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbxLogin;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\Authorisation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TbxPassword;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\Authorisation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAuth;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Pages\Authorisation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TbRegUri;
        
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
            System.Uri resourceLocater = new System.Uri("/Lapshin_FitnessClub;component/pages/authorisation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Authorisation.xaml"
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
            this.TbxLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TbxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.BtnAuth = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Pages\Authorisation.xaml"
            this.BtnAuth.Click += new System.Windows.RoutedEventHandler(this.BtnAuth_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TbRegUri = ((System.Windows.Controls.TextBlock)(target));
            
            #line 66 "..\..\..\Pages\Authorisation.xaml"
            this.TbRegUri.MouseEnter += new System.Windows.Input.MouseEventHandler(this.TbRegUri_MouseEnter);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\Pages\Authorisation.xaml"
            this.TbRegUri.MouseLeave += new System.Windows.Input.MouseEventHandler(this.TbRegUri_MouseLeave);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\Pages\Authorisation.xaml"
            this.TbRegUri.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TbRegUri_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

