   M S B A M L   `   `   `  ����\  X1612431_Final_2018_Management_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:_1612431_Final_2018_Management_app"_1612431_Final_2018_Management_app  5      7    1_1612431_Final_2018_Management_app.BillManagePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:_1612431_Final_2018_Management_app     5      -   5        $��692.5��5	      $
��1103��6     N� Title$  BillManagePage��5
      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��BillListDataGrid��5      $��Hidden=�5   H   
�������   AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     	RowHeight$ 50Q�5      $	��692��5   #   $��Center=�5      $��Center=�5         
IsReadOnly . $
��1103��5      
 �� Top$ 2��6*      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Mã hoá đơn��5      
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      ��  �� Path$ ID�5        5      $	 Mã khách hàng��5      $	
 200 5        5      �� $ 
CustomerID�5!        5#      $	 
Ngày bán��5$      $	
 200 5&       5%      �� $
 Date�5'        5)      $	 Mã khuyến mãi��5*      $	
 200 5,       5+      �� $ PromotionCode�5-        5/      $	 Thành tiền��50      $	
 200 52       51      �� $ TotalAmount�53        55      $	 Thanh toán��56      $	
 200 58       57      �� $ 	PayMethod�59      5;      5<      5=      