   M S B A M L   `   `   `  ����\  X1612431_Final_2018_Management_app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:_1612431_Final_2018_Management_app"_1612431_Final_2018_Management_app  5      9    3_1612431_Final_2018_Management_app.DetailBillManage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:_1612431_Final_2018_Management_app     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��692.5��5	      $
��1103��6     N� Title$  DetailBillManage��5
      .��5      � .+�5   
   �� -   5        $��CustomerNameTextBox��5      {�.  $��40��6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên khách hàng��6K    %  !MaterialDesignFloatingHintTextBox#��[  6{   $��67,-5,846,657q�6�   �� 5   
   -   5        $��CustomerPhoneTextBox��5      {�.  $��40��6@   $ Số điện thoại��6L   #��[  6{   $��295,-5,615,657q�6�   �� 5   
   -   5        $��CustomerAdressTextBox��5      $	��ALd��6/   {�.  $��40��6L   $ Địa chỉ��6X   #��[  6�   $��544,-5,138,657q�6�   �� 5   
   -   5        $��OriginalPriceTextBox��5      {�.  $��40��6@   $ Số tiền gốc��6L   #��[  6y   $��67,50,846,602q�6�   �� 5   
   -   5        $��PromotionTextBox��5      {�.  $��40��6<   $ Tổng khuyến mãi��6H   #��[  6y   $��295,50,615,602q�6�   �� 5   
   -   5        $��TotalAmountTextBox��5      $	��ALd��6,   {�.  $��40��6I   $ Tổng tiền trả��6U   #��[  6�   $��544,50,318,602q�6�   �� 5   
   -   5         ��Name$ 	ResetDate��5      
������  � ToolTip$* $Đặt lại thời gian thống kê��6U   $
��Auto��6z   $
��Auto��6�   $��992,20,10,609q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
���   ��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowBack=�69   $��53��6J   $��53��6U   $��0q�6a   5      &   System.Windows.Controls.DataGrid  5   
   -	   5        $��ProductListDataGrid��5       $��Hidden=�5      
�������   AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .  	   	RowHeight$		 130Q�5      $	��493��5   #   $��Center=�5      $��Center=�5!      
   
IsReadOnly
 . $
��1100��5#      
 �� Top$ 2��6*   $��
0,105,0,94q�69      Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$              Sản phẩm��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6H      CellTemplate 5)      �� 5*      .R�5+      �� $	��130��6E   ��6$   �� *ProductSource+6T   5,      5.      0  *System.Windows.Controls.DataGridTextColumn  50      $ Tên sản phẩm��51      $	 200 53      1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 52      ��  �� Path$
 Name�54        56      $ 
Giá gốc��57      $	 120 58       59      �� $ OriginalPrice�5:        5<      $ 	Giá bán��5=      $	 120 5>       5?      �� $ DisplayPrice�5@        5B      $ Số lượng��5C      $	 150 5D       5E      �� $ Quantity�5F        5H      $ Khuyến mãi��5I      $	 150 5J       5K      �� $ 	Promotion�5L        5N      $ Thành tiền��5O      $ * 5P       5Q      �� $ Amount�5R      5U      5X      5Y      