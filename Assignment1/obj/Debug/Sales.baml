   M S B A M L   `   `   `  ����F  BAssignment1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment1Assignment1  5   	       Assignment1.Sales   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment1     5   	     � Title$  Sales��5   	   $	��600��6   $
��1200��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��583* �6   �� 5      $
��617* �6    � RowDefinitions 5   
   �� 5      $	��40* �6   �� 5      $	��33* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $��2��6%   $��21,320,26,34q�69   $��2��6O   �� 5   
   -   5         ��Name$ 
BtnShowAll��5      $��1��6%   $��Show All Products��65   $
��Left=�6Q   $��
155,70,0,0q�6l   $	��Top=�6�   $��41��6�   $	��238��6�   $��16(�6�   $
��Bold"�6�   $��Arial)�6�   6�   �� 5   
   -   5        $ 	BtnChkOut��5      $��1��6$   $��	Check Out��64   $
��Left=�6H   $��155,196,0,0q�6c   $	��Top=�6x   $��41��6�   $	��238��6�   $��16(�6�   $
��Bold"�6�   $��Arial)�6�   6�   �� 5   
   -   5         ��Name$ 	TBProIdSr��5      $
��Left=�6%   $��
186,72,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��144��6�   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   $��28��6�   �� 5   
   $��Product ID:��6   $
��Left=�6&   $��	39,72,0,0q�6A   $	��Top=�6T   $��16(�6l   $��Arial)�6z   $
��Bold"�6�    J� RenderTransformOrigin$ -0.014,0.315&�6�   �� 5   
   $��Amount(Kg):��6   $
��Left=�6&   $��
36,122,0,0q�6A   $	��Top=�6U   $��16(�6m   $��Arial)�6{   $
��Bold"�6�   $ -0.014,0.315&�6�   �� 5   
   -   5        $ TBProAm��5      $
��Left=�6#   $��185,122,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��144��6   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   $��28��6�   �� 5   
   -   5        $ BtnAdd��5      $��1��6!   $��Add Product to Cart��61   $
��Left=�6O   $��155,138,0,0q�6j   $	��Top=�6   $��41��6�   $	��238��6�   $��16(�6�   $
��Bold"�6�   $��Arial)�6�   6�   �� 5   
   $��Total Sales :��6   $
��Left=�6(   $��
36,198,0,0q�6C   $	��Top=�6W   $��16(�6o   $��Arial)�6}   $
��Bold"�6�   $ -0.014,0.315&�6�   �� 5   
   -   5         ��Name$ 	lbl_total��5      $�� ��6#   $
��Left=�6.   $��185,200,0,0q�6I   $	��Top=�6^   $��96��6v   $��16(�6�   $
��Bold"�6�   $��Arial)�6�   5      5      