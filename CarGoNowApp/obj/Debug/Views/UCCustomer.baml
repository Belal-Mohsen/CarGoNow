   M S B A M L   `   `   `  ����F  BCarGoNowApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarGoNowApp.ViewsCarGoNowApp.Views  5      "    CarGoNowApp.Views.UCCustomer   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:CarGoNowApp.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   � $��0��6     5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6     � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� $��Customer ID:��6   $��1��6+   $��0��68   $��10,10,213,10q�6H   $
��Bold"�6^   $��14(�6p   $��Comic Sans MS)�6~   �� 5      -   5         ��Name$ txtCustomerID��5      $��1��6-   $��0��6:   $��129,10,44,10q�6J    J� RenderTransformOrigin$ 0.5,0.5&�6`   $��14(�6�   $
��Bold"�6�   {�.  6�   �� 5       $��First Name:��6   $��2��6*   $��0��67   $��10,10,213,10q�6G   $
��Bold"�6]   $��14(�6o   $��Comic Sans MS)�6}   �� 5!      -   5        $ txtFirstName��5!      $��2��6,   $��0��69   $��129,10,44,10q�6I   $��14(�6_   $
��Bold"�6m   �� 5#      $��
Last Name:��6   $��3��6)   $��0��66   $��10,10,213,10q�6F   $
��Bold"�6\   $��14(�6n   $��Comic Sans MS)�6|   �� 5$      -   5        $ txtLastName��5$      $��3��6+   $��0��68   $��129,10,44,10q�6H   $��14(�6^   $
��Bold"�6l   �� 5&      $��
Phone No.:��6   $��1��6)   $��1��66   $��10,10,168,10q�6F   $
��Bold"�6\   $��14(�6n   $��Comic Sans MS)�6|   �� 5'      -   5        $ txtPhone��5'      $��1��6(   $��1��65   $��121,12,52,8q�6E   $��14(�6Z   $
��Bold"�6h   �� 5)      $��Email:��6   $��2��6%   $��1��62   $��10,12,189,8q�6B   $
��Bold"�6W   $��14(�6i   $��Comic Sans MS)�6w   �� 5*      -   5        $ txtEmail��5*      $��2��6(   $��1��65   $��121,12,53,8q�6E   $��14(�6Z   $
��Bold"�6h   �� 5,      $��Driving License:��6   $��3��6/   $��1��6<   $��10,12,150,8q�6L   $
��Bold"�6a   $��14(�6s   $��Comic Sans MS)�6�   �� 5-      -   5        $ txtDLicense��5-      $��3��6+   $��1��68   $��121,10,53,10q�6H   $��14(�6^   $
��Bold"�6l   �� 5/      $��Expiry Date:��6   $��4��6+   $��0��68   $��
10,0,150,0q�6H   $
��Bold"�6\   $��14(�6n   $��Comic Sans MS)�6|   (  "System.Windows.Controls.DatePicker  50      -   5          Name$ pickerDLicenseED��50      $��4��63   $��0��6@   $��129,9,44,11q�6P   $��14(�6e   $
��Bold"�6s   �� 52      -   5        $��Delete��52      $��3��6&   $��2��63   $��
11,6,152,5q�6C   $��25��6r   �� 53      -	   5        $��Update��53      $��2��6&   $��2��63   $��
11,6,152,5q�6C   $��25��6r   �� 54      -
   5        $	��Add��54      $��1��6&   $��2��63   $��
11,3,152,0q�6C   $��25��6q   55      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ dataGrid��56      $��1��6%   6]   58      59      