﻿#pragma checksum "..\..\PurchasePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D1B1B45E849C81BCCCE65E770FF462851E7FC3E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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
using _1612431_Final_2018_Management_app;


namespace _1612431_Final_2018_Management_app {
    
    
    /// <summary>
    /// PurchasePage
    /// </summary>
    public partial class PurchasePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShopingCartButton;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel CategoryListStackPanel;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CategoryListView;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StartPriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider StartPriceSlider;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EndPriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider EndPriceSlider;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyPriceButton;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\PurchasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListviewItem;
        
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
            System.Uri resourceLocater = new System.Uri("/1612431_Final_2018_Management_app;component/purchasepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PurchasePage.xaml"
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
            
            #line 10 "..\..\PurchasePage.xaml"
            ((_1612431_Final_2018_Management_app.PurchasePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 65 "..\..\PurchasePage.xaml"
            this.NameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ShopingCartButton = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\PurchasePage.xaml"
            this.ShopingCartButton.Click += new System.Windows.RoutedEventHandler(this.ShopingCartButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CategoryListStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.CategoryListView = ((System.Windows.Controls.ListView)(target));
            
            #line 115 "..\..\PurchasePage.xaml"
            this.CategoryListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoryListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 129 "..\..\PurchasePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StartPriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.StartPriceSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 141 "..\..\PurchasePage.xaml"
            this.StartPriceSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.StartPriceSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.EndPriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.EndPriceSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 148 "..\..\PurchasePage.xaml"
            this.EndPriceSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.EndPriceSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ApplyPriceButton = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\PurchasePage.xaml"
            this.ApplyPriceButton.Click += new System.Windows.RoutedEventHandler(this.ApplyPriceButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ListviewItem = ((System.Windows.Controls.ListView)(target));
            
            #line 154 "..\..\PurchasePage.xaml"
            this.ListviewItem.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListviewItem_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
