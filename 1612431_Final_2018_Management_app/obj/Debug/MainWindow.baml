   M S B A M L   `   `   `  ����\  X1612431_Final_2018_Management_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:_1612431_Final_2018_Management_app"_1612431_Final_2018_Management_app  5   	   M IFluent, Version=7.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent 5   	   3    -_1612431_Final_2018_Management_app.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:_1612431_Final_2018_Management_app     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     5   	   -   5          � Title$  QUẢN LÝ BÁN HÀNG��5
   	   $	��750��6"   $
��1103��6/    � WindowStartupLocation$ CenterScreen=�6Y   .��5      ]� ��. .+�5   
     Fluent.Ribbon  -   5        $��ribbon��5   -   $	��Top=�6   !   IsAutomaticCollapseEnabled .    Menu 5        Fluent.Backstage  5        Fluent.RibbonControl   Header$
 File��6#   
��� � �   Content. 5         Fluent.BackstageTabControl  .@�5        Fluent.BackstageTabItem     Header$ Options��62   5        5      $ About��62   5      5      5         Tabs. 5        Fluent.RibbonTabItem     Header$ Sản phẩm��6#   5        5      $ 
Quản lý��6#   	   Groups.	 5         Fluent.RibbonGroupBox  $	��180��6(   $��Sản phẩm��64   .@�5!        Fluent.Button  -   5        $��ProductButton��5!   {   
   	LargeIcon$
 image/product.png��6$   $��82��6B      Header$ 
Hàng hoá��6i   6�     5"      -   5        $��
BillButton��5"   t   $
 image/bill.png��6$   $��82��6?   $ 
Hoá đơn��6c   6�   5#        5%      $��90��6(   .@�5&        -   5        $��PromotionButton��5&   �   $
 image/promotion.png��6$   $��82��6D   $ Khuyến mãi��6m   6�   5'        5)      $	��180��6(   $��Thống kê��64   .@�5*        -   5        $��ProductsStatisticButton��5*   �   $!
 image/productsStatistic.png��6$   $��82��6r   $ Sản phẩm��6~   6�     5+      -   5        $��SalesStatisticButton��5+   �   $
 image/salesStatistic.png��6$   $��82��6l   $ 	Doanh thu��6x   6�   5,      5.      5/      �� 51   
   -   5        $
��tabs��51      $��0q�6e    �� SelectedIndex 6!   ��  �� ElementName$ ribbon�� �� Path$ SelectedTabIndex� � 	Resources 52       �� 
TargetType �� Property �� Value �� 
TargetType��%w   '��       �� 53      " ��6   .�54      ��  � �� 55      �� 56      " ��6.   6E   58      59      5:      5;      5<      5>      